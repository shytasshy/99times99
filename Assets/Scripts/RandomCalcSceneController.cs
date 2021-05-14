using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCalcSceneController : MonoBehaviour
{
    [SerializeField] private Text selectnum_text = default;
    [SerializeField] private Text ansnum_text = default;
    [SerializeField] private Text left_num_text = default;
    [SerializeField] private Text right_num_text = default;
    [SerializeField] private GameObject after_checkbutton_object = default;
    [SerializeField] private AnimationCurve tabMoveCurve = default;
    [SerializeField] private Canvas canvas = default;
    [SerializeField] private GameObject tab_panel = default;
    [SerializeField] private GameObject tab_container = default;
    [SerializeField] private GameObject page_container = default;
    [SerializeField] private GameObject page0 = default;
    public static int ans_num;
    public static int select_num;
    public static int left_num;
    public static int right_num;
    public static List<int> tab_flag_list;
    public static List<GameObject> tab_list;
    void Start()
    {
        select_num = 0;
        left_num = Random.Range(1, 100);
        right_num = Random.Range(1, 100);
        ans_num = left_num * right_num;
        selectnum_text.text = "";
        left_num_text.text = left_num.ToString();
        right_num_text.text = right_num.ToString();
        ansnum_text.text = ans_num.ToString();
        tab_list = new List<GameObject>();
    }

    public void PushNumButton(int number)
    {
        selectnum_text.text = selectnum_text.text + number.ToString();
    }

    //1文字消す
    public void PushDelButton()
    {
        if (selectnum_text.text.Length != 0)
        {
            selectnum_text.text = selectnum_text.text.Substring(0, selectnum_text.text.Length - 1);
        }
    }

    //全部消す
    public void PushClrButton()
    {
        selectnum_text.text = "";
    }

    public void PushCheckButton()
    {
        //入力した解答text(selectnum_text)をint(select_num)に格納
        if (selectnum_text.text.Length != 0)
        {
            select_num = int.Parse(selectnum_text.text);
        }
        else
        {
            select_num = 0;
        }

        //解答の数字が正解なら青、不正解なら赤
        if (ans_num == select_num)
        {
            selectnum_text.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            selectnum_text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        //正しい解答と解説ボタンを表示
        after_checkbutton_object.gameObject.SetActive(true);
        tab_panel.SetActive(true);

    }

    public static int get_ans_num()
    {
        return ans_num;
    }

    public static int get_select_num()
    {
        return select_num;
    }

    public static int get_left_num()
    {
        return left_num;
    }

    public static int get_right_num()
    {
        return right_num;
    }

    public void PushCommentButton()
    {
        /*tab create*/
        tab_flag_list = Calc_tab_num(get_left_num(),get_right_num());
        tab_list = new List<GameObject>();
        for (int i = 0; i < tab_flag_list.Count; i++) {
            tab_list.Add(SetTabObject(i,tab_flag_list));
        }
        tab_list[0].GetComponent<Toggle>().isOn = true;
        tab_list[0].GetComponent<Toggle>().Select();
        CalcColumnMultiplication(get_left_num(), get_right_num(), page_container.transform.Find("Page0").gameObject);
        CalcAddDifProduction(get_left_num(), get_right_num(), page_container.transform.Find("Page1").gameObject);

        /*move tab panel*/
        StartCoroutine(moveUpCommentPanel(tab_panel,new Vector3(0.0f,-155.0f,0.0f)));
    }

    public void PushCloseCommentButton()
    {
        /*move tab panel*/
        StartCoroutine(moveDownCommentPanel(tab_panel, new Vector3(0.0f, -485.0f, 90.0f)));
    }

    public List<int> Calc_tab_num(int left_num, int right_num)
    {
        var tab_flag_list = new List<int>();
        tab_flag_list.Add(1);
        tab_flag_list.Add((left_num + right_num) % 2 == 1 ? 0 : 1);
        tab_flag_list.Add(1);
        return tab_flag_list;
    }

    public GameObject SetTabObject(int i, List<int> tab_list)
    {

        Transform tab_trf = tab_container.transform.Find("Tab" + i.ToString());

/*        tab_trf.localPosition = new Vector3(i * 40 - 92, 148, 0);
        tab_trf.localScale = new Vector3(1, 1, 1);*/
        if(tab_list[i] == 0){
            tab_trf.gameObject.GetComponent<Toggle>().interactable = false;
            tab_trf.Find("Background/text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }

        return tab_trf.gameObject;
    }

    public void CalcColumnMultiplication(int left_num, int right_num, GameObject clm_page_obj)
    {
        int LTenP = left_num / 10;
        string LTenP_s = LTenP.ToString();
        if (LTenP == 0)
        {
            LTenP_s = "";
        }

        string LOneP_s = (left_num % 10).ToString();


        int RTenP = right_num / 10;
        string RTenP_s = RTenP.ToString();
        if (RTenP == 0)
        {
            RTenP_s = "";
        }

        string ROneP_s = (right_num % 10).ToString();


        int OHunP = (left_num * (right_num % 10)) / 100;
        string OHunP_s = OHunP.ToString();
        if(OHunP == 0)
        {
            OHunP_s = "";
        }

        int OTenP = ((left_num * (right_num % 10)) / 10) % 10;
        string OTenP_s = OTenP.ToString();
        if(OHunP ==0 && OTenP == 0)
        {
            OTenP_s = "";
        }

        int OOneP = (left_num * (right_num % 10)) % 10;
        string OOneP_s = OOneP.ToString();

        int Sub_OTenP = ((left_num % 10) * (right_num % 10)) / 10;
        string Sub_OTenP_s = Sub_OTenP.ToString();
        if (Sub_OTenP==0)
        {
            Sub_OTenP_s = "";
        }


        int THunP = (left_num * (right_num / 10)) / 100;
        string THunP_s = THunP.ToString();
        if (THunP == 0)
        {
            THunP_s = "";
        }

        int TTenP = ((left_num * (right_num / 10)) / 10) % 10;
        string TTenP_s = TTenP.ToString();
        if (THunP == 0 && TTenP == 0)
        {
            TTenP_s = "";
        }

        int TOneP = (left_num * (right_num / 10)) % 10;
        string TOneP_s = TOneP.ToString();

        int Sub_TTenP = ((left_num % 10) * (right_num / 10)) / 10;
        string Sub_TTenP_s = Sub_TTenP.ToString();
        if (Sub_TTenP == 0)
        {
            Sub_TTenP_s = "";
        }

        int AThoP = (left_num * right_num) / 1000;
        string AThoP_s = AThoP.ToString();
        if (AThoP == 0)
        {
            AThoP_s = "";
        }

        int AHunP = ((left_num * right_num) / 100) % 10;
        string AHunP_s = AHunP.ToString();
        if(AThoP==0 && AHunP == 0)
        {
            AHunP_s = "";
        }

        int ATenP = ((left_num * right_num) / 10) % 10;
        string ATenP_s = ATenP.ToString();
        if(AThoP==0 && AHunP ==0 && ATenP == 0)
        {
            ATenP_s = "";
        }

        int AOneP = (left_num * right_num) % 10;
        string AOneP_s = AOneP.ToString();

        int Sub_AHunP = (OTenP + TOneP) / 10;
        int Sub_AThoP = (Sub_AHunP + OHunP + TTenP) / 10;
        string Sub_AHunP_s = Sub_AHunP.ToString();
        string Sub_AThoP_s = Sub_AThoP.ToString();
        if (Sub_AHunP == 0)
        {
            Sub_AHunP_s = "";
        }
        if (Sub_AThoP == 0)
        {
            Sub_AThoP_s = "";
        }


        clm_page_obj.transform.Find("Objects0/LTenP").GetComponent<Text>().text = LTenP_s;
        clm_page_obj.transform.Find("Objects0/LOneP").GetComponent<Text>().text = LOneP_s;
        clm_page_obj.transform.Find("Objects0/RTenP").GetComponent<Text>().text = RTenP_s;
        clm_page_obj.transform.Find("Objects0/ROneP").GetComponent<Text>().text = ROneP_s;
        clm_page_obj.transform.Find("Objects1/1HunP").GetComponent<Text>().text = OHunP_s;
        clm_page_obj.transform.Find("Objects1/1TenP").GetComponent<Text>().text = OTenP_s;
        clm_page_obj.transform.Find("Objects1/1OneP").GetComponent<Text>().text = OOneP_s;
        clm_page_obj.transform.Find("Objects2/2HunP").GetComponent<Text>().text = THunP_s;
        clm_page_obj.transform.Find("Objects2/2TenP").GetComponent<Text>().text = TTenP_s;
        clm_page_obj.transform.Find("Objects2/2OneP").GetComponent<Text>().text = TOneP_s;
        clm_page_obj.transform.Find("Objects3/AThoP").GetComponent<Text>().text = AThoP_s;
        clm_page_obj.transform.Find("Objects3/AHunP").GetComponent<Text>().text = AHunP_s;
        clm_page_obj.transform.Find("Objects3/ATenP").GetComponent<Text>().text = ATenP_s;
        clm_page_obj.transform.Find("Objects3/AOneP").GetComponent<Text>().text = AOneP_s;
        clm_page_obj.transform.Find("Objects1/S1TenP").GetComponent<Text>().text = Sub_OTenP_s;
        clm_page_obj.transform.Find("Objects2/S2TenP").GetComponent<Text>().text = Sub_TTenP_s;
        clm_page_obj.transform.Find("Objects3/SAHunP").GetComponent<Text>().text = Sub_AHunP_s;
        clm_page_obj.transform.Find("Objects3/SAThoP").GetComponent<Text>().text = Sub_AThoP_s;

    }

    public void CalcAddDifProduction(int left_num, int right_num, GameObject clm_page_obj)
    {
        int add = (left_num + right_num)/2;
        int diff = Mathf.Abs(left_num - right_num)/2;
        clm_page_obj.transform.Find("Objects0/Text1").GetComponent<Text>().text = "① 和÷2：( " + left_num + " + " + right_num + " )÷2 = " +add + "\n② 差÷2：| "+ left_num + " - " + right_num  + " | ÷2 = " + diff.ToString();
        clm_page_obj.transform.Find("Objects1/Text2").GetComponent<Text>().text = "①^2：" + add + "^2 = " + add*add + "\n②^2：" + diff + "^2 = " + diff*diff;
        clm_page_obj.transform.Find("Objects2/Text3").GetComponent<Text>().text = "①^2 - ②^2：" + add * add + " - " + diff * diff;
        clm_page_obj.transform.Find("Objects2/Text4").GetComponent<Text>().text = " = " + (add * add - diff * diff);

    }


    public IEnumerator moveObject(GameObject obj, Vector3 targetPosition)
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

    public IEnumerator moveUpCommentPanel(GameObject obj, Vector3 targetPosition)
    {
        float currentTime = 0;
        float moveTime = 0.4f;
        Vector3 startPosition = obj.transform.localPosition;
        Vector3 position = targetPosition - startPosition;

        tab_container.SetActive(true);
        GameObject.FindWithTag("CoBtn").transform.localPosition -= new Vector3(0.0f, 20.0f, 0.0f);
        GameObject.FindWithTag("CoBtnI").transform.localPosition -= new Vector3(0.0f, 20.0f, 0.0f);
        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = false;
        tab_panel.transform.Find("CloseCommentButton").gameObject.SetActive(true);
        tab_panel.transform.Find("CloseCommentButtonImage").gameObject.SetActive(true);
/*        GameObject.FindWithTag("ClCoBtn").transform.localPosition += new Vector3(0.0f, 200.0f, 0.0f);*/

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float scale = tabMoveCurve.Evaluate(currentTime / moveTime);
            obj.transform.localPosition = startPosition + scale * position;
            yield return null;
        }
    }

    public IEnumerator moveDownCommentPanel(GameObject obj, Vector3 targetPosition)
    {
        float currentTime = 0;
        float moveTime = 0.4f;
        Vector3 startPosition = obj.transform.localPosition;
        Vector3 position = targetPosition - startPosition;

        GameObject.FindWithTag("ClCoBtn").SetActive(false);
        GameObject.FindWithTag("ClCoBtnI").SetActive(false);
        GameObject.FindWithTag("CoBtn").transform.localPosition += new Vector3(0.0f, 20.0f, 0.0f);
        GameObject.FindWithTag("CoBtnI").transform.localPosition += new Vector3(0.0f, 20.0f, 0.0f);

        while (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float scale = tabMoveCurve.Evaluate(currentTime / moveTime);
            obj.transform.localPosition = startPosition + scale * position;
            yield return null;
        }

/*        GameObject.FindWithTag("ClCoBtn").transform.localPosition -= new Vector3(0.0f, 200.0f, 0.0f);*/
        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = true;
        tab_container.SetActive(false);

    }

    public void PushRightButton(GameObject page)
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

    public void PushLeftButton(GameObject page)
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

    public IEnumerator waitMoment(float time)
    {
        yield return time;
    }

}
