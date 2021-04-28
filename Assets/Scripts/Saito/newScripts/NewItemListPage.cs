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
}
