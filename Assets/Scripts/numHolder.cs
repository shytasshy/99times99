using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numHolder : MonoBehaviour
{
    public static int left_num;
    public static int right_num;
    public static int num_for_square;
    public static bool left_num_is_random=true;
    public static bool right_num_is_random=true;
    public static bool Square_display = false;
    // Start is called before the first frame update
    void Start()
    {
        if (left_num_is_random)
        {
            left_num = Random.Range(1, 100);
        }
        if (right_num_is_random)
        {
            right_num = Random.Range(1, 100);
        }
        num_for_square = Random.Range(1, 100);
    }

    public static void lock_left_num()
    {
        left_num_is_random = !left_num_is_random;
    }

    public static void lock_right_num()
    {
        right_num_is_random = !right_num_is_random;
    }

    public static void set_left_num(int i)
    {
        left_num = i;
        left_num_is_random = false;
    }

    public static void set_right_num(int i)
    {
        right_num = i;
        right_num_is_random = false;
    }

    public static void set_Square_display()
    {
        if (Square_display)
        {
            Square_display = false;
        }
        else
        {
            Square_display = true;
        }
    }
}
