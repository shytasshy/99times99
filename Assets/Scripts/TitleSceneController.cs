using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text tenPlaceText = default;
    [SerializeField] private Text onePlaceText = default;
    public static int tenPlaceNumber = 5;
    public static int onePlaceNumber = 0;

    void Start()
    {
        tenPlaceText.text = tenPlaceNumber.ToString();
        onePlaceText.text = onePlaceNumber.ToString();
    }

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

    // Update is called once per frame
    public void OnSetCalculatorButton()
    {
        numHolder.SetLeftNumber(tenPlaceNumber*10+onePlaceNumber);
        SceneManager.LoadScene("CalculatorScene");
    }

    public void OnRandomCalculatorButton()
    {
        numHolder.leftNumberIsRandom = true;
        numHolder.rightNumberIsRandom = true;
        SceneManager.LoadScene("CalculatorScene");
    }

    public void OnSquareCalculaorButton()
    {
        SceneManager.LoadScene("SquareCalculatorScene");
    }
}
