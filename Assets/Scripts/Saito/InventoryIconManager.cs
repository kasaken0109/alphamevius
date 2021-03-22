using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 今後textをイラストに変更
/// </summary>
public class InventoryIconManager : MonoBehaviour
{
    [SerializeField] int m_itemID = 0;
    int m_itemPossessionCount = 0;
    Text m_text;
    ItemEnum m_itemEnum;
    private void Start()
    {
        m_text = transform.Find("Text").gameObject.GetComponent<Text>();
        m_itemEnum = (ItemEnum)m_itemID;
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
}
