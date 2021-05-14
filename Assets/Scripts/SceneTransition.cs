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
        numHolder.left_num_random_flag = true;
        numHolder.right_num_random_flag = true;
        SceneManager.LoadScene("RandomCalcScene");
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
