using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemManager : MonoBehaviour
{
    ToolType m_equipmentItem = ToolType.None;
    List<int> m_itemList = new List<int>();
    int[] m_hotbarID = new int[10];
    [SerializeField] NewItemLibrary m_library = null;
    private void Start()
    {
        for (int i = 0; i < m_library.GetAllItemsNumber(); i++)
        {
            m_itemList.Add(0);
        }
    }
    public ToolType GetEquipmentItem()
    {
        return m_equipmentItem;
    }
    public void SetEquipmentItem(ToolType toolType)
    {
        m_equipmentItem = toolType;
    }
    public void AddItem(int ID,int number)
    {
        m_itemList[ID] += number;      
    }
    public void SubItem(int ID, int number)
    {
        m_itemList[ID] -= number;
    }
    public int GetHaveItem(int ID)
    {
        return m_itemList[ID];
    }
    //public Sprite GetSprite(int ID)
    //{
    //    return m_library.GetS
    //}
}
