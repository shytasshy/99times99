using UnityEngine;

//ボタンの挙動の定義
public class PushButtonController : MonoBehaviour
{
    private bool _buttonDown = false;

    //押下中の表現
    public void OnButtonDown()
    {
        _buttonDown = true;
        this.gameObject.transform.localPosition += new Vector3(0.0f, -9.0f);
        this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, 0.0f);
    }

    //ボタン上で押下をやめたとき
    public void OnButtonUp()
    {
        if (_buttonDown)
        {
            _buttonDown = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 9.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -9.0f);
        }
    }

    //ボタン上から指がスライドして外に出た時
    public void OnButtonExit()
    {
        if (_buttonDown)
        {
            _buttonDown = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 9.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -9.0f);
        }
    }
}
