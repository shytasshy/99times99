using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public static List<int> Calc_tab_num(int left_num, int right_num)
    {
        List<int> tab_flag_list = new List<int>();
        tab_flag_list.Add(1);
        tab_flag_list.Add((left_num + right_num) % 2 == 1 ? 0 : 1);
        tab_flag_list.Add(1);
        return tab_flag_list;
    }

    public static void Calc_ColumnMultiplication(int left_num, int right_num, GameObject clm_page_obj)
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
        if (OHunP == 0)
        {
            OHunP_s = "";
        }

        int OTenP = ((left_num * (right_num % 10)) / 10) % 10;
        string OTenP_s = OTenP.ToString();
        if (OHunP == 0 && OTenP == 0)
        {
            OTenP_s = "";
        }

        int OOneP = (left_num * (right_num % 10)) % 10;
        string OOneP_s = OOneP.ToString();

        int Sub_OTenP = ((left_num % 10) * (right_num % 10)) / 10;
        string Sub_OTenP_s = Sub_OTenP.ToString();
        if (Sub_OTenP == 0)
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
        if (AThoP == 0 && AHunP == 0)
        {
            AHunP_s = "";
        }

        int ATenP = ((left_num * right_num) / 10) % 10;
        string ATenP_s = ATenP.ToString();
        if (AThoP == 0 && AHunP == 0 && ATenP == 0)
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

    public static void Calc_AddDifProduction(int left_num, int right_num, GameObject clm_page_obj)
    {
        int add = (left_num + right_num) / 2;
        int diff = Mathf.Abs(left_num - right_num) / 2;
        clm_page_obj.transform.Find("Objects0/Text1").GetComponent<Text>().text = "① 和÷2：( " + left_num + " + " + right_num + " )÷2 = " + add + "\n② 差÷2：| " + left_num + " - " + right_num + " | ÷2 = " + diff.ToString();
        clm_page_obj.transform.Find("Objects1/Text2").GetComponent<Text>().text = "①^2：" + add + "^2 = " + add * add + "\n②^2：" + diff + "^2 = " + diff * diff;
        clm_page_obj.transform.Find("Objects2/Text3").GetComponent<Text>().text = "①^2 - ②^2：" + add * add + " - " + diff * diff;
        clm_page_obj.transform.Find("Objects2/Text4").GetComponent<Text>().text = " = " + (add * add - diff * diff);

    }



}
