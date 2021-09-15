using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionSceneController : MonoBehaviour
{
    [SerializeField] private Text selectNumberText = default;
    [SerializeField] private Text answerNumberText = default;
    [SerializeField] private Text leftNumberText = default;
    [SerializeField] private Text rightNumberText = default;
    [SerializeField] private Text squareNumberText = default;
    [SerializeField] private GameObject afterCheckButtonObjects = default;

    [SerializeField] private AnimationCurve tabMoveCurve = default;

    [SerializeField] private Canvas canvas = default;
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
    void Start()
    {
        selectNumber = 0;
        tabList = new List<GameObject>();
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "CalculatorScene")
        {
            leftNumber = NumberHolder.leftNumber;
            rightNumber = NumberHolder.rightNumber;
            Debug.Log("leftNumber:" + leftNumber);
            if(NumberHolder.leftNumberIsRandom == false)
            {
                leftNumberText.gameObject.transform.Find("frame").gameObject.SetActive(true);
            }
            if(NumberHolder.rightNumberIsRandom == false)
            {
                rightNumberText.gameObject.transform.Find("frame").gameObject.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "SquareCalculatorScene")
        {
            if (NumberHolder.squareDisplay)
            {
                displayPanel.transform.Find("Objects0").gameObject.SetActive(false);
                displayPanel.transform.Find("Objects1").gameObject.SetActive(true);
            }
            else
            {
                displayPanel.transform.Find("Objects0").gameObject.SetActive(true);
                displayPanel.transform.Find("Objects1").gameObject.SetActive(false);
            }
            leftNumber = NumberHolder.numberForSquare;
            rightNumber = NumberHolder.numberForSquare;
            squareNumber = NumberHolder.numberForSquare;
            squareNumberText.text = squareNumber.ToString();
        }

        leftNumberText.text = leftNumber.ToString();
        rightNumberText.text = rightNumber.ToString();

        answerNumber = leftNumber * rightNumber;
        answerNumberText.text = answerNumber.ToString();
    }

    public void OnNumberButton(int number)
    {
        if(selectNumberText.text == "0")
        {
            if(number != 0)
            {
                selectNumberText.text = number.ToString();
            }
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
        //入力した解答text(selectnum_text)をint(select_num)に格納
        if (selectNumberText.text.Length != 0)
        {
            selectNumber = int.Parse(selectNumberText.text);
        }
        else
        {
            selectNumber = 0;
        }

        //解答の数字が正解なら青、不正解なら赤
        if (answerNumber == selectNumber)
        {
            selectNumberText.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            selectNumberText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        //正しい解答と解説ボタンを表示
        afterCheckButtonObjects.gameObject.SetActive(true);
        tabPanel.SetActive(true);

    }

    public void OnCommentButton()
    {
        /*tab create*/
        //tab_flag_list：n番目の解法が使えるならtrue
        //tab_list：使える解法のTab_nのtransform
        createTabList = CommentGenerator.GetCreateTabList(leftNumber,rightNumber);

        tabList = tabController.CreateTabList(createTabList, tabContainer);

        tabList[0].GetComponent<Toggle>().isOn = true;
        tabList[0].GetComponent<Toggle>().Select();

        //2乗モードか通常モードごとに解説欄を計算
        if (SceneManager.GetActiveScene().name == "SquareCalculatorScene")
        {
            CommentGenerator.CreateSquareComment(leftNumber, pageContainer.transform.Find("Page0").gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "CalculatorScene")
        {
            CommentGenerator.CreateColumnMultiplicationComment(leftNumber, rightNumber, pageContainer.transform.Find("Page0").gameObject);
            CommentGenerator.CreateAddDiffProductionComment(leftNumber, rightNumber, pageContainer.transform.Find("Page1").gameObject);
        }
        /*move tab panel*/
        StartCoroutine(MoveUpCommentPanel(tabPanel,new Vector3(0.0f,-651.0f,0.0f)));
    }

    public void OnCloseCommentButton()
    {
        /*move tab panel*/
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

    public void OnRightButton(GameObject page)
    {
        int i = 1;
        while(page.transform.Find("Objects"+i)!=null)
        {
            if(page.transform.Find("Objects" + i).gameObject.activeSelf == false)
            {
                page.transform.Find("Objects" + i).gameObject.SetActive(true);
                return;
            }
            i++;
        }
    }

    public void OnLeftButton(GameObject page)
    {
        int i = 1;
        while(page.transform.Find("Objects"+i)!=null)
        {
            i++;
        }
        for(int j = i-1; j > 0; j--)
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
        if (NumberHolder.leftNumberIsRandom)
        {
            leftNumberText.gameObject.transform.Find("frame").gameObject.SetActive(false);
        }
        else
        {
            leftNumberText.gameObject.transform.Find("frame").gameObject.SetActive(true);
        }
    }

    public void OnRightLockButton()
    {
        NumberHolder.LockRightNumber();
        if(NumberHolder.rightNumberIsRandom)
        {
            rightNumberText.gameObject.transform.Find("frame").gameObject.SetActive(false);
        }
        else
        {
            rightNumberText.gameObject.transform.Find("frame").gameObject.SetActive(true);
        }
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
            displayPanel.transform.Find("Objects0").gameObject.SetActive(false);
            displayPanel.transform.Find("Objects1").gameObject.SetActive(true);
        }
        else
        {
            displayPanel.transform.Find("Objects0").gameObject.SetActive(true);
            displayPanel.transform.Find("Objects1").gameObject.SetActive(false);
        }
    }

}
