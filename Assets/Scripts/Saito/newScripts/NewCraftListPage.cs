using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCraftListPage : MonoBehaviour
{
    [SerializeField] NewCraftItem[] m_craftList;
    public void UpdatePage(int item, int ID)
    {
        m_craftList[item].ChangeImage(ID);
    }
    public void UpdateItemColor()
    {
        foreach (var item in m_craftList)
        {
            if (item.IsCraftCheck())
            {
                item.ChangeNormalColor();
            }
            else
            {
                item.ChangeCantCraftColor();
            }
        }
    }
}
