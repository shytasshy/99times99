
using UnityEngine;

//かける数とかけられる数の管理
public class NumberHolder : MonoBehaviour
{
    public static int leftNumber { get; private set; } = 0;
    public static int rightNumber { get; private set; } = 0;
    public static int numberForSquare { get; private set; } = 0;
    public static bool leftNumberIsRandom=true;
    public static bool rightNumberIsRandom=true;
    public static bool squareDisplay = false;
    //ページのリロードの度にかける数とかけられる数を生成
    void Start()
    {
        leftNumber = leftNumberIsRandom ? Random.Range(1, 100) : leftNumber;
        rightNumber = rightNumberIsRandom ? Random.Range(1, 100) : rightNumber;
        numberForSquare = Random.Range(1, 100);
    }

    //リロードしても左(右)の文字を入れ替えないようにする(偶数回でロック解除)
    public static void LockLeftNumber()
    {
        leftNumberIsRandom = !leftNumberIsRandom;
    }

    public static void LockRightNumber()
    {
        rightNumberIsRandom = !rightNumberIsRandom;
    }

    //左右の数字を予め固定する(数字を指定して計算するモード用)
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

    //二乗の計算モードで掛け算表記と乗数表記の表示方法を切り替える
    public static void ChangeSquareDisplay()
    {
        squareDisplay = !squareDisplay;
    }
}
