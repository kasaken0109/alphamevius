using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemListPage : MonoBehaviour
{
    [SerializeField] NewInventoryItem[] m_itemList;
    public void UpdatePage(int item,int ID)
    {
        m_itemList[item].ChangeImage(ID);
    }
    public NewInventoryItem[] GetItemList() { return m_itemList; }
    public void EquipmentItem(int ID)
    {
        if (ID == 0)
        {
            EMarkControl.Instance.CloseEquipment();
            return;
        }
        foreach (var item in m_itemList)
        {
            if (item.GetID() == ID)
            {
                item.SetEquipmentMark();
            }
        }
    }
}
