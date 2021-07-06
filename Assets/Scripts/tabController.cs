using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public static GameObject SetTabObject(int i, List<bool> tab_flag_list, GameObject tab_container)
    {

        Transform tab_trf = tab_container.transform.Find("Tab" + i.ToString());

        if (tab_flag_list[i] == false)
        {
            tab_trf.gameObject.GetComponent<Toggle>().interactable = false;
            tab_trf.Find("Background/text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }

        return tab_trf.gameObject;
    }

    public static List<GameObject> get_TabList(List<bool> tab_flag_list, GameObject tab_container)
    {
        List<GameObject> tab_list = new List<GameObject>();
        for (int i = 0; i < tab_flag_list.Count; i++)
        {
            tab_list.Add(SetTabObject(i, tab_flag_list,tab_container));
        }
        return tab_list;
    }

}
