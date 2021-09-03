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
    public static GameObject CreateTab(int tabNumber, List<bool> createTabList, GameObject tabContainer)
    {

        Transform tabTransform = tabContainer.transform.Find("Tab" + tabNumber.ToString());

        if (createTabList[tabNumber] == false)
        {
            tabTransform.gameObject.GetComponent<Toggle>().interactable = false;
            tabTransform.Find("Background/text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }

        return tabTransform.gameObject;
    }

    public static List<GameObject> CreateTabList(List<bool> createTabList, GameObject tabContainer)
    {
        List<GameObject> tabList = new List<GameObject>();
        for (int i = 0; i < createTabList.Count; i++)
        {
            tabList.Add(CreateTab(i, createTabList,tabContainer));
        }
        return tabList;
    }

}
