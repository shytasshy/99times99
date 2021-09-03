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

    public static List<bool> GetCreateTabList(int leftNumber, int rightNumber)
    {
        List<bool> createTabList = new List<bool>();
        createTabList.Add(true);//筆算
        createTabList.Add((leftNumber + rightNumber) % 2 == 1 ? false : true);//和と差の積
        createTabList.Add(true);//
        Debug.Log(createTabList);
        return createTabList;
    }

    public static void CreateColumnMultiplicationComment(int leftNumber, int rightNumber, GameObject page)
    {
        int leftTenPlaceNumber = leftNumber / 10;
        string leftTenPlaceText = leftTenPlaceNumber.ToString();
        if (leftTenPlaceNumber == 0)
        {
            leftTenPlaceText = "";
        }

        string leftOnePlaceText = (leftNumber % 10).ToString();


        int rightTenPlaceNumber = rightNumber / 10;
        string rightTenPlaceText = rightTenPlaceNumber.ToString();
        if (rightTenPlaceNumber == 0)
        {
            rightTenPlaceText = "";
        }

        string rightOnePlaceText = (rightNumber % 10).ToString();


        int firstHundredPlaceNumber = (leftNumber * (rightNumber % 10)) / 100;
        string firstHundredPlaceText = firstHundredPlaceNumber.ToString();
        if (firstHundredPlaceNumber == 0)
        {
            firstHundredPlaceText = "";
        }

        int firstTenPlaceNumber = ((leftNumber * (rightNumber % 10)) / 10) % 10;
        string firstTenPlaceText = firstTenPlaceNumber.ToString();
        if (firstHundredPlaceNumber == 0 && firstTenPlaceNumber == 0)
        {
            firstTenPlaceText = "";
        }

        int firstOnePlaceNumber = (leftNumber * (rightNumber % 10)) % 10;
        string firstOnePlaceText = firstOnePlaceNumber.ToString();

        int firstTenPlaceSubNumber = ((leftNumber % 10) * (rightNumber % 10)) / 10;
        string firstTenPlaceSubText = firstTenPlaceSubNumber.ToString();
        if (firstTenPlaceSubNumber == 0)
        {
            firstTenPlaceSubText = "";
        }


        int secondHundredPlaceNumber = (leftNumber * (rightNumber / 10)) / 100;
        string secondHundredPlaceText = secondHundredPlaceNumber.ToString();
        if (secondHundredPlaceNumber == 0)
        {
            secondHundredPlaceText = "";
        }

        int secondTenPlaceNumber = ((leftNumber * (rightNumber / 10)) / 10) % 10;
        string secondTenPlaceText = secondTenPlaceNumber.ToString();
        if (secondHundredPlaceNumber == 0 && secondTenPlaceNumber == 0)
        {
            secondTenPlaceText = "";
        }

        int secondOnePlaceNumber = (leftNumber * (rightNumber / 10)) % 10;
        string secondOnePleceText = secondOnePlaceNumber.ToString();

        int secondTenPlaceSubNumber = ((leftNumber % 10) * (rightNumber / 10)) / 10;
        string secondTenPlaceSubText = secondTenPlaceSubNumber.ToString();
        if (secondTenPlaceSubNumber == 0)
        {
            secondTenPlaceSubText = "";
        }

        int answerThousandPlaceNumber = (leftNumber * rightNumber) / 1000;
        string answerThousandPlaceText = answerThousandPlaceNumber.ToString();
        if (answerThousandPlaceNumber == 0)
        {
            answerThousandPlaceText = "";
        }

        int answerHundredPlaceNumber = ((leftNumber * rightNumber) / 100) % 10;
        string answerHundredPlaceText = answerHundredPlaceNumber.ToString();
        if (answerThousandPlaceNumber == 0 && answerHundredPlaceNumber == 0)
        {
            answerHundredPlaceText = "";
        }

        int answerTenPlaceNumber = ((leftNumber * rightNumber) / 10) % 10;
        string answerTenPlaceText = answerTenPlaceNumber.ToString();
        if (answerThousandPlaceNumber == 0 && answerHundredPlaceNumber == 0 && answerTenPlaceNumber == 0)
        {
            answerTenPlaceText = "";
        }

        int answerOnePlaceNumber = (leftNumber * rightNumber) % 10;
        string answerOnePlaceText = answerOnePlaceNumber.ToString();

        int answerHundredPlaceSubNumber = (firstTenPlaceNumber + secondOnePlaceNumber) / 10;
        int answerThousandPlaceSubNumber = (answerHundredPlaceSubNumber + firstHundredPlaceNumber + secondTenPlaceNumber) / 10;
        string answerHundredPlaceSubText = answerHundredPlaceSubNumber.ToString();
        string answerThousandPlaceSubText = answerThousandPlaceSubNumber.ToString();
        if (answerHundredPlaceSubNumber == 0)
        {
            answerHundredPlaceSubText = "";
        }
        if (answerThousandPlaceSubNumber == 0)
        {
            answerThousandPlaceSubText = "";
        }


        page.transform.Find("Objects0/LTenP").GetComponent<Text>().text = leftTenPlaceText;
        page.transform.Find("Objects0/LOneP").GetComponent<Text>().text = leftOnePlaceText;
        page.transform.Find("Objects0/RTenP").GetComponent<Text>().text = rightTenPlaceText;
        page.transform.Find("Objects0/ROneP").GetComponent<Text>().text = rightOnePlaceText;
        page.transform.Find("Objects1/1HunP").GetComponent<Text>().text = firstHundredPlaceText;
        page.transform.Find("Objects1/1TenP").GetComponent<Text>().text = firstTenPlaceText;
        page.transform.Find("Objects1/1OneP").GetComponent<Text>().text = firstOnePlaceText;
        page.transform.Find("Objects2/2HunP").GetComponent<Text>().text = secondHundredPlaceText;
        page.transform.Find("Objects2/2TenP").GetComponent<Text>().text = secondTenPlaceText;
        page.transform.Find("Objects2/2OneP").GetComponent<Text>().text = secondOnePleceText;
        page.transform.Find("Objects3/AThoP").GetComponent<Text>().text = answerThousandPlaceText;
        page.transform.Find("Objects3/AHunP").GetComponent<Text>().text = answerHundredPlaceText;
        page.transform.Find("Objects3/ATenP").GetComponent<Text>().text = answerTenPlaceText;
        page.transform.Find("Objects3/AOneP").GetComponent<Text>().text = answerOnePlaceText;
        page.transform.Find("Objects1/S1TenP").GetComponent<Text>().text = firstTenPlaceSubText;
        page.transform.Find("Objects2/S2TenP").GetComponent<Text>().text = secondTenPlaceSubText;
        page.transform.Find("Objects3/SAHunP").GetComponent<Text>().text = answerHundredPlaceSubText;
        page.transform.Find("Objects3/SAThoP").GetComponent<Text>().text = answerThousandPlaceSubText;

    }

    public static void CreateAddDiffProductionComment(int leftNumber, int rightNumber, GameObject page)
    {
        int add = (leftNumber + rightNumber) / 2;
        int diff = Mathf.Abs(leftNumber - rightNumber) / 2;
        page.transform.Find("Objects0/Text1").GetComponent<Text>().text = "① 和÷2：( " + leftNumber + " + " + rightNumber + " )÷2 = " + add + "\n② 差÷2：| " + leftNumber + " - " + rightNumber + " | ÷2 = " + diff.ToString();
        page.transform.Find("Objects1/Text2").GetComponent<Text>().text = "①^2：" + add + "^2 = " + add * add + "\n②^2：" + diff + "^2 = " + diff * diff;
        page.transform.Find("Objects2/Text3").GetComponent<Text>().text = "①^2 - ②^2：" + add * add + " - " + diff * diff;
        page.transform.Find("Objects2/Text4").GetComponent<Text>().text = " = " + (add * add - diff * diff);

    }

    public static void CreateSquareComment(int number, GameObject page)
    {
        int square = number * number;
        int firstNumber;
        int secondNumber;
        string formulaText = null;
        string secondText = null;
        string thirdText = null;
        string answerText = null;

        if (number < 25)
        {
            Debug.Log("a");
            page.transform.Find("Objects0/Default").gameObject.SetActive(true);
            Debug.Log("a_fin");
        }
        else if (number >= 25 && number <= 75)
        {
            Debug.Log("b");
            page.transform.Find("Objects0/Default").gameObject.SetActive(false);
            firstNumber = (number - 25) * 100;
            secondNumber = (number - 50) * (number - 50);
            formulaText = "25 ≦ a ≦ 75のとき\n( a - 25 ) * 100 + ( a - 50 )^2";
            secondText = "( " + (number - 25) + " ) * 100 + ( " + (number - 50) + " )^2";
            thirdText = "= " + firstNumber + " + " + secondNumber;
            answerText = "= " + square;
            Debug.Log("b_fin");
        }
        else if (number > 75)
        {
            Debug.Log("c");
            page.transform.Find("Objects0/Default").gameObject.SetActive(false);
            firstNumber = (2 * number - 100) * 100;
            secondNumber = (number - 100) * (number - 100);
            formulaText = "a > 75のとき\n( 2a - 100 ) * 100 + ( a - 100 ) ^2";
            secondText = "( " + (2 * number - 100) + " ) * 100 + ( " + (number - 100) + " )^2";
            thirdText = "= " + firstNumber + " + " + secondNumber;
            answerText = "= " + square;
            Debug.Log("c_fin");
        }

        page.transform.Find("Objects0/Formula1").GetComponent<Text>().text = formulaText;
        page.transform.Find("Objects0/Formula2").GetComponent<Text>().text = secondText;
        page.transform.Find("Objects0/Formula3").GetComponent<Text>().text = thirdText;
        page.transform.Find("Objects0/Ans").GetComponent<Text>().text = answerText;
    }

}
