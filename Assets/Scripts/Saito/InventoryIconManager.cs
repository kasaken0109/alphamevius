using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/// <summary>
/// 今後textをイラストに変更
/// </summary>
public class InventoryIconManager : MonoBehaviour
{
    int m_itemPossessionCount = 0;
    Text m_text;
    [SerializeField] ItemBaseMain m_item;
    [SerializeField] ItemEnum m_itemEnum;
    private void Start()
    {
        m_text = transform.Find("Text").gameObject.GetComponent<Text>();
        m_itemPossessionCount = ItemManage.Instance.itemList[m_itemEnum];
        InventoryNumChange();
    }
    private void Update()
    {
        if (m_itemPossessionCount != ItemManage.Instance.itemList[m_itemEnum])
        {
            InventoryNumChange();
        }
    }
    public void InventoryNumChange()
    {
        m_text.text = m_itemEnum.ToString() + " : " +  ItemManage.Instance.itemList[m_itemEnum].ToString();
    }
    public void DebugTest()
    {
        Debug.Log("動いてくれ");
    }
    public void SelectItem(int ID)
    {
        //ItemEnum type = (ItemEnum)Enum.ToObject(typeof(ItemEnum), ID);
        //Debug.Log("選択");
        //HotBarManager.Instance.SetHotBar(ID);
    }
}
