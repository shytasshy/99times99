using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentSceneController : MonoBehaviour
{
    [SerializeField] private Text selectnum_text = default;
    private int left_num;
    private int right_num;
    private int ans_num;
    // Start is called before the first frame update
    void Start()
    {
        this.left_num = RandomCalcSceneController.get_left_num();
        this.right_num = RandomCalcSceneController.get_right_num();
        this.ans_num = RandomCalcSceneController.get_ans_num();
        selectnum_text.text = this.ans_num.ToString();
    }
    

}
