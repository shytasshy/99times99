﻿using System.Collections;
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
    [SerializeField] private Transform parentTransform = default;
    [SerializeField] private AnimationCurve tabMoveCurve = default;
    [SerializeField] private Canvas canvas = default;
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
        tab_flag_list = Calc_tab_num(get_left_num(),get_right_num());
        tab_list = new List<GameObject>();
            for (int i = 0; i < tab_flag_list.Count; i++) {
            tab_list.Add(CreateTabObject(i,tab_flag_list));
        }
        tab_list[0].GetComponent<Toggle>().isOn = true;
        tab_list[0].GetComponent<Toggle>().Select();
        GameObject.FindWithTag("CoBtn").transform.localPosition += new Vector3(0.0f, 20.0f, 0.0f);
        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = false;
        GameObject.FindWithTag("ClCoBtn").transform.localPosition += new Vector3(0.0f, 200.0f, 0.0f);
        StartCoroutine(moveObject(GameObject.FindWithTag("TabP"),new Vector3(0.0f,-190.0f,0.0f)));
        
    }

    public void PushCloseCommentButton()
    {
        for(int i = 0; i < tab_list.Count; i++)
        {
            tab_list[i].transform.localPosition = Vector3.zero;
        }
        GameObject.FindWithTag("CoBtn").transform.localPosition -= new Vector3(0.0f, 20.0f, 0.0f);
        GameObject.FindWithTag("ClCoBtn").transform.localPosition -= new Vector3(0.0f, 200.0f, 0.0f);
        GameObject.FindWithTag("CoBtn").GetComponent<Button>().interactable = true;
        StartCoroutine(moveObject(GameObject.FindWithTag("TabP"), new Vector3(0.0f, -450.0f, 90.0f)));
    /*tab_listをfor文で検索してpositionをzeroに*/
        /*CoBtnもとに戻す*/
        /*TabPanelを元に戻す*/

    }

    public List<int> Calc_tab_num(int left_num, int right_num)
    {
        var tab_flag_list = new List<int>();
        tab_flag_list.Add(1);
        tab_flag_list.Add(0);
        tab_flag_list.Add(1);
        return tab_flag_list;
    }

    public GameObject CreateTabObject(int i, List<int> tab_list)
    {

        GameObject tab_obj = GameObject.FindWithTag("tab"+i.ToString());
 //       tab_obj.transform.SetParent(parentTransform);
 //       tab_obj.transform.Find("Background").position = new Vector3(100, 0,0);
/* togglegroup = tabcontainer(parent) */
 //       ToggleGroup tab_togglegroup = tab_obj.transform.parent.GetComponent<ToggleGroup>();
 //       tab_obj.GetComponent<Toggle>().group = tab_togglegroup;

/*tab position*/
        tab_obj.transform.localPosition = new Vector3(i*45-92,210,0);
        tab_obj.transform.localScale = new Vector3(1, 1, 1);
        if(tab_list[i] == 0){
            tab_obj.GetComponent<Toggle>().interactable = false;
            tab_obj.transform.Find("Background").Find("text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }

        return tab_obj;
    }

    public IEnumerator moveObject(GameObject obj,Vector3 targetPosition)
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

}
