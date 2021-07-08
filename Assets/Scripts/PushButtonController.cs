using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonController : MonoBehaviour
{
    private bool buttonDownFlag = false;
    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnButtonDown()
    {
        buttonDownFlag = true;
        this.gameObject.transform.localPosition += new Vector3(0.0f, -1.0f);
        this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, 0.0f);
    }

    public void OnButtonUp()
    {
        if (buttonDownFlag)
        {
            buttonDownFlag = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 1.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -1.0f);
        }
    }

    public void OnButtonExit()
    {
        if (buttonDownFlag)
        {
            buttonDownFlag = false;
            this.gameObject.transform.localPosition += new Vector3(0.0f, 1.0f);
            this.gameObject.GetComponent<UnityEngine.UI.Shadow>().effectDistance = new Vector2(0.0f, -1.0f);
        }
    }
}
