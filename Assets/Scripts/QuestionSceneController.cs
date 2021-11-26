using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
public class QuestionSceneController : MonoBehaviour
{
    [SerializeField] private Text selectNumberText = default;
    [SerializeField] private Text answerNumberText = default;
    [SerializeField] private Text leftNumberText = default;
    [SerializeField] private Text rightNumberText = default;
    [SerializeField] private Text squareNumberText = default;
    [SerializeField] private GameObject afterCheckButtonObjects = default;
    [SerializeField] private AnimationCurve tabMoveCurve = default;
    [SerializeField] private GameObject tabPanel = default;
    [SerializeField] private GameObject displayPanel = default;
    [SerializeField] private GameObject tabContainer = default;
    [SerializeField] private GameObject pageContainer = default;
    public int answerNumber;
    public int selectNumber;
    public int leftNumber;
    public int rightNumber;
    public int squareNumber;
    public List<bool> createTabList;
    public List<GameObject> tabList;

    //
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CalculatorScene")
        {
            leftNumber = NumberHolder.leftNumber;
            rightNumber = NumberHolder.rightNumber;
            leftNumberText.gameObject.transform.Find("frame").gameObject.SetActive(!NumberHolder.leftNumberIsRandom);
            rightNumberText.gameObject.transform.Find("frame").gameObject.SetActive(!NumberHolder.rightNumberIsRandom);
        }
        else if (SceneManager.GetActiveScene().name == "SquareCalculatorScene")
        {
            leftNumber = NumberHolder.numberForSquare;
            rightNumber = NumberHolder.numberForSquare;
            squareNumber = NumberHolder.numberForSquare;
            squareNumberText.text = squareNumber.ToString();

            if (NumberHolder.squareDisplay)
            {
                displayPanel.transform.Find("MultiplyDisplay").gameObject.SetActive(false);
                displayPanel.transform.Find("ExponentDisplay").gameObject.SetActive(true);
            }
            else
            {
                displayPanel.transform.Find("MultiplyDisplay").gameObject.SetActive(true);
                displayPanel.transform.Find("ExponentDisplay").gameObject.SetActive(false);
            }
        }

        leftNumberText.text = leftNumber.ToString();
        rightNumberText.text = rightNumber.ToString();

        answerNumber = leftNumber * rightNumber;
        answerNumberText.text = answerNumber.ToString();
    }

    //
    public void OnNumberButton(int number)
    {
        if(selectNumberText.text == "0")
        {
            if(number != 0)　{selectNumberText.text = number.ToString();}
            return;
        }

        selectNumberText.text = selectNumberText.text + number.ToString();
    }

    //1文字消す
    public void OnDeleteButton()
    {
        if (selectNumberText.text.Length != 0)
        {
            selectNumberText.text = selectNumberText.text.Substring(0, selectNumberText.text.Length - 1);
        }
    }

    //全部消す
    public void OnClearButton()
    {
        selectNumberText.text = "";
    }

    public void OnCheckButton()
    {
        //入力した解答(空なら0)
        selectNumber = selectNumberText.text.Length != 0 ? int.Parse(selectNumberText.text) : 0;

        //解答の数字が正解なら青、不正解なら赤
        selectNumberText.color = selectNumber == answerNumber ? new Color(0.0f, 0.0f, 1.0f, 1.0f): new Color(1.0f, 0.0f, 0.0f, 1.0f);

        //正しい解答と解説ボタンを表示
        afterCheckButtonObjects.gameObject.SetActive(true);
        tabPanel.SetActive(true);

    }

    public void OnCommentButton()
    {
        //createTabList：n番目の解法が使えるならtrue
        //tabList：tabのtransform
        createTabList = CommentGenerator.GetCreateTabList(leftNumber,rightNumber);

        tabList = tabController.CreateTabList(createTabList, tabContainer);

        tabList[0].GetComponent<Toggle>().isOn = true;
        tabList[0].GetComponent<Toggle>().Select();

        //モードか通常モードごとに解説欄を計算
        if (SceneManager.GetActiveScene().name == "SquareCalculatorScene")
        {
            CommentGenerator.CreateSquareComment(leftNumber, pageContainer.transform.Find("Page0").gameObject);
        }

        if (SceneManager.GetActiveScene().name == "CalculatorScene")
        {
            CommentGenerator.CreateColumnMultiplicationComment(leftNumber, rightNumber, pageContainer.transform.Find("Page0").gameObject);
            CommentGenerator.CreateAddDiffProductionComment(leftNumber, rightNumber, pageContainer.transform.Find("Page1").gameObject);
        }

        //解説パネルを上へ
        StartCoroutine(MoveUpCommentPanel(tabPanel,new Vector3(0.0f,-651.0f,0.0f)));
    }

    public void OnCloseCommentButton()
    {
        //解説パネルを下へ
        StartCoroutine(MoveDownCommentPanel(tabPanel, new Vector3(0.0f, -1850.0f, 90.0f)));
    }

    public IEnumerator MoveObject(GameObject obj, Vector3 targetPosition)
    {
        float currentTime = 0;
        float moveTime = 0.6f;

        Vector3 startPosition = obj.transform.localPosition;

        Vector3 position = targetPosition - startPosition;

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float scale = tabMoveCurve.Evaluate(currentTime / moveTime);
            obj.transform.localPosition = startPosition + scale * position;
            yield return null;
        }
    }

    //各種ボタンを表示して解説パネルを上へ
    public IEnumerator MoveUpCommentPanel(GameObject obj, Vector3 targetPosition)
    {
        float currentTime = 0;
        float moveTime = 0.4f;
        Vector3 startPosition = obj.transform.localPosition;
        Vector3 position = targetPosition - startPosition;

        tabContainer.SetActive(true);
        GameObject.FindWithTag("CoBtn").transform.localPosition -= new Vector3(0.0f, 84.0f, 0.0f);
        GameObject.FindWithTag("CoBtnI").transform.localPosition -= new Vector3(0.0f, 84.0f, 0.0f);
        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = false;
        tabPanel.transform.Find("CloseCommentButton").gameObject.SetActive(true);
        tabPanel.transform.Find("CloseCommentButtonImage").gameObject.SetActive(true);

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float scale = tabMoveCurve.Evaluate(currentTime / moveTime);
            obj.transform.localPosition = startPosition + scale * position;
            yield return null;
        }
    }

    //各種ボタンを非表示にしてから解説パネルを下へ
    public IEnumerator MoveDownCommentPanel(GameObject obj, Vector3 targetPosition)
    {
        float currentTime = 0;
        float moveTime = 0.4f;
        Vector3 startPosition = obj.transform.localPosition;
        Vector3 position = targetPosition - startPosition;

        GameObject.FindWithTag("ClCoBtn").SetActive(false);
        GameObject.FindWithTag("ClCoBtnI").SetActive(false);
        GameObject.FindWithTag("CoBtn").transform.localPosition += new Vector3(0.0f, 84.0f, 0.0f);
        GameObject.FindWithTag("CoBtnI").transform.localPosition += new Vector3(0.0f, 84.0f, 0.0f);

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float scale = tabMoveCurve.Evaluate(currentTime / moveTime);
            obj.transform.localPosition = startPosition + scale * position;
            yield return null;
        }

        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = true;
        tabContainer.SetActive(false);

    }

    //解説の文を進める
    public void OnRightButton(GameObject page)
    {
        int i = 1;
        while(page.transform.Find("Objects"+i)!=null)
        {
            //非表示のうち一番若いものをアクティブにしてリターン
            if(page.transform.Find("Objects" + i).gameObject.activeSelf == false)
            {
                page.transform.Find("Objects" + i).gameObject.SetActive(true);
                return;
            }
            i++;
        }
    }

    //解説の文を非表示に戻す
    public void OnLeftButton(GameObject page)
    {
        int objectNumber = 1;
        while(page.transform.Find("Objects" + objectNumber)!=null)
        {
            objectNumber++;
        }

        //アクティブのうち一番老い番を非表示にしてリターン
        for(int j = objectNumber-1; j > 0; j--)
        {
            if (page.transform.Find("Objects" + j).gameObject.activeSelf == true)
            {
                page.transform.Find("Objects" + j).gameObject.SetActive(false);
                return;
            }
        }
    }

    public void OnLeftLockButton()
    {
        NumberHolder.LockLeftNumber();
        leftNumberText.gameObject.transform.Find("frame").gameObject.SetActive(!NumberHolder.leftNumberIsRandom);
    }

    public void OnRightLockButton()
    {
        NumberHolder.LockRightNumber();
        rightNumberText.gameObject.transform.Find("frame").gameObject.SetActive(!NumberHolder.rightNumberIsRandom);
    }

    public IEnumerator WaitMoment(float time)
    {
        yield return time;
    }

    public void OnSquareDisplayButton()
    {
        NumberHolder.ChangeSquareDisplay();
        if (NumberHolder.squareDisplay)
        {
            displayPanel.transform.Find("MultiplyDisplay").gameObject.SetActive(false);
            displayPanel.transform.Find("ExponentDisplay").gameObject.SetActive(true);
        }
        else
        {
            displayPanel.transform.Find("MultiplyDisplay").gameObject.SetActive(true);
            displayPanel.transform.Find("ExponentDisplay").gameObject.SetActive(false);
        }
    }

}
