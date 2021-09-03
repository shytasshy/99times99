using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonController : MonoBehaviour
{
    private bool _buttonDownFlag = false;
    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnButtonDown()
    {
        _buttonDownFlag = true;
        this.gameObject.transform.localPosition += new Vector3(0.0f, -9.0f);
        this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, 0.0f);
    }

    public void OnButtonUp()
    {
        if (_buttonDownFlag)
        {
            _buttonDownFlag = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 9.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -9.0f);
        }
    }

    public void OnButtonExit()
    {
        if (_buttonDownFlag)
        {
            _buttonDownFlag = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 9.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -9.0f);
        }
    }
}
