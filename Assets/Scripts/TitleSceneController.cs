using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text ten_num_text = default;
    [SerializeField] private Text one_num_text = default;
    public static int ten_num = 5;
    public static int one_num = 0;

    void Start()
    {
        ten_num_text.text = ten_num.ToString();
        one_num_text.text = one_num.ToString();
    }

    public void PushTenUpButton()
    {
        ten_num = ten_num != 9 ? ten_num + 1 : 0;
        ten_num_text.text = ten_num.ToString();
    }

    public void PushTenDownButton()
    {
        ten_num = ten_num != 0 ? ten_num - 1 : 9;
        ten_num_text.text = ten_num.ToString();
    }

    public void PushOneUpButton()
    {
        one_num = one_num != 9 ? one_num + 1 : 0;
        one_num_text.text = one_num.ToString();
    }

    public void PushOneDownButton()
    {
        one_num = one_num != 0 ? one_num - 1 : 9;
        one_num_text.text = one_num.ToString();
    }

    // Update is called once per frame
    public void PushSetLeftButton()
    {
        numHolder.set_left_num(ten_num*10+one_num);
        SceneManager.LoadScene("QuestionScene");
    }

    public void PushRandomCalcButton()
    {
        numHolder.left_num_is_random = true;
        numHolder.right_num_is_random = true;
        SceneManager.LoadScene("QuestionScene");
    }
}
