using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushRandomCalcSceneButton()
    {
        SceneManager.LoadScene("QuestionScene");
    }

    public void PushTitleSceneButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void PushCommentSceneButton()
    {
        SceneManager.LoadScene("CommentScene");
    }
}
