using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//タイトル画面＝モード選択画面
public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Text tenPlaceText = default;
    [SerializeField] private Text onePlaceText = default;
    public static int tenPlaceNumber = 5;
    public static int onePlaceNumber = 0;

    
    void Start()
    {
        tenPlaceText.text = tenPlaceNumber.ToString();
        onePlaceText.text = onePlaceNumber.ToString();
    }

    //段指定のためのボタン４つ
    public void OnTenUpButton()
    {
        tenPlaceNumber = tenPlaceNumber != 9 ? tenPlaceNumber + 1 : 0;
        tenPlaceText.text = tenPlaceNumber.ToString();
    }

    public void OnTenDownButton()
    {
        tenPlaceNumber = tenPlaceNumber != 0 ? tenPlaceNumber - 1 : 9;
        tenPlaceText.text = tenPlaceNumber.ToString();
    }

    public void OnOneUpButton()
    {
        onePlaceNumber = onePlaceNumber != 9 ? onePlaceNumber + 1 : 0;
        onePlaceText.text = onePlaceNumber.ToString();
    }

    public void OnOneDownButton()
    {
        onePlaceNumber = onePlaceNumber != 0 ? onePlaceNumber - 1 : 9;
        onePlaceText.text = onePlaceNumber.ToString();
    }

    //段を指定して計算モードを始める
    public void OnSetCalculatorButton()
    {
        NumberHolder.SetLeftNumber(tenPlaceNumber*10+onePlaceNumber);
        SceneManager.LoadScene("CalculatorScene");
    }

    //ランダムの計算モードを始める
    public void OnRandomCalculatorButton()
    {
        NumberHolder.leftNumberIsRandom = true;
        NumberHolder.rightNumberIsRandom = true;
        SceneManager.LoadScene("CalculatorScene");
    }

    //二乗の計算モードを始める
    public void OnSquareCalculaorButton()
    {
        SceneManager.LoadScene("SquareCalculatorScene");
    }
}
