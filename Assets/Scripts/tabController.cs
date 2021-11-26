using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//解説ページの各タブを管理
public class tabController : MonoBehaviour
{

    //タブを１つ生成
    public static GameObject CreateTab(int tabNumber, List<bool> createTabList, GameObject tabContainer)
    {

        Transform tabTransform = tabContainer.transform.Find("Tab" + tabNumber.ToString());

        //解説ページが適用できないケースはページのタブをインタラクティブにして表示を薄くする
        if (createTabList[tabNumber] == false)
        {
            tabTransform.gameObject.GetComponent<Toggle>().interactable = false;
            tabTransform.Find("Background/text").GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        }

        return tabTransform.gameObject;
    }

    //タブの一覧の作成
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
