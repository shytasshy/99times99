using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberHolder : MonoBehaviour
{
    public static int leftNumber { get; set; }
    public static int rightNumber { get; set; }
    public static int numberForSquare;
    public static bool leftNumberIsRandom=true;
    public static bool rightNumberIsRandom=true;
    public static bool squareDisplay = false;
    // Start is called before the first frame update
    void Start()
    {
        if (leftNumberIsRandom)
        {
            leftNumber = Random.Range(1, 100);
        }
        if (rightNumberIsRandom)
        {
            rightNumber = Random.Range(1, 100);
        }
        numberForSquare = Random.Range(1, 100);
    }

    public static void LockLeftNumber()
    {
        leftNumberIsRandom = !leftNumberIsRandom;
    }

    public static void LockRightNumber()
    {
        rightNumberIsRandom = !rightNumberIsRandom;
    }

    public static void SetLeftNumber(int number)
    {
        leftNumber = number;
        leftNumberIsRandom = false;
    }

    public static void SetRightNumber(int number)
    {
        rightNumber = number;
        rightNumberIsRandom = false;
    }

    public static void ChangeSquareDisplay()
    {
        if (squareDisplay)
        {
            squareDisplay = false;
        }
        else
        {
            squareDisplay = true;
        }
    }
}
