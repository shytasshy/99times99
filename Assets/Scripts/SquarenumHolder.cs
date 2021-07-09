using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarenumHolder : MonoBehaviour
{
    public static int left_num;
    public static int right_num;
    public static bool left_num_random_flag = true;
    public static bool right_num_random_flag = true;
    // Start is called before the first frame update
    void Start()
    {
        if (left_num_random_flag)
        {
            left_num = Random.Range(1, 100);
        }
        right_num = left_num;
    }

    public static void lock_left_num()
    {
        left_num_random_flag = !left_num_random_flag;
    }

    public static void lock_right_num()
    {
        right_num_random_flag = !right_num_random_flag;
    }

    public static void set_left_num(int i)
    {
        left_num = i;
        left_num_random_flag = false;
    }

    public static void set_right_num(int i)
    {
        right_num = i;
        right_num_random_flag = false;
    }

}
