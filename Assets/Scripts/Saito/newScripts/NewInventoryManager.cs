using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    [SerializeField] NewInventoryItem[] m_craftList;
    [SerializeField] NewInventoryItem[] m_itemList;
    [SerializeField] NewInventoryItem[] m_recycleList;
    [SerializeField] NewInventoryItem[] m_cookingList;
    private void Start()
    {
        ItemListUpdate();
    }
    public void ItemListUpdate()
    {
        List<int> itemList = NewItemManager.Instance.GetHaveItemID();
        for (int i = 0; i < itemList.Count; i++)
        {
            m_itemList[i].ChangeImage(itemList[i]);
        }
    }
}
