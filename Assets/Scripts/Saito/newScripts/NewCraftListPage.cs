using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCraftListPage : MonoBehaviour
{
    [SerializeField] NewCraftItem[] m_craftList;
    public void UpdatePage(int item, int ID)
    {
        Debug.Log(ID + "a");
        m_craftList[item].ChangeImage(ID);
    }
}
