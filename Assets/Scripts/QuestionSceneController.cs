﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionSceneController : MonoBehaviour
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
    public int ans_num;
    public int select_num;
    public int left_num;
    public int right_num;
    public int num_for_square; 
    public List<bool> tab_flag_list;
    public List<GameObject> tab_list;
    void Start()
    {
        select_num = 0;
        left_num = numHolder.left_num;
        right_num = numHolder.right_num;
        num_for_square = numHolder.num_for_square;
        ans_num = left_num * right_num;
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

    public void PushCommentButton()
    {
        /*tab create*/
        //tab_flag_list：n番目の解法が使えるならtrue
        //tab_list：使える解法のTab_nのtransform
        tab_flag_list = Calculator.Calc_tab_num(left_num,right_num);

        tab_list = tabController.get_TabList(tab_flag_list, tab_container);

        tab_list[0].GetComponent<Toggle>().isOn = true;
        tab_list[0].GetComponent<Toggle>().Select();

        //2乗モードか通常モードごとに解説欄を計算
        if (SceneManager.GetActiveScene().name == "SquareCalcScene")
        {
            Calculator.Calc_Square(num_for_square, page_container.transform.Find("Page0").gameObject);
        }
        else if (SceneManager.GetActiveScene().name == "QuestionScene")
        {
            Calculator.Calc_ColumnMultiplication(left_num, right_num, page_container.transform.Find("Page0").gameObject);
            Calculator.Calc_AddDifProduction(left_num, right_num, page_container.transform.Find("Page1").gameObject);
        }
        /*move tab panel*/
        StartCoroutine(moveUpCommentPanel(tab_panel,new Vector3(0.0f,-155.0f,0.0f)));
    }

    public void PushCloseCommentButton()
    {
        /*move tab panel*/
        StartCoroutine(moveDownCommentPanel(tab_panel, new Vector3(0.0f, -440.0f, 90.0f)));
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

    public void PushLeftLockButton()
    {
        numHolder.lock_left_num();
        Debug.Log(numHolder.left_num_is_random+"!!!");
    }

    public IEnumerator waitMoment(float time)
    {
        yield return time;
    }

}
