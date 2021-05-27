using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRecycleListPage : MonoBehaviour
{
    [SerializeField] NewRecycleItem[] m_recycleList;
    public void UpdatePage(int item, int ID)
    {
        m_recycleList[item].ChangeImage(ID);
    }
}
