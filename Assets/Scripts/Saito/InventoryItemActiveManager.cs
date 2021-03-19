using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryItemActiveManager : MonoBehaviour
{
    ItemEnum m_itemEnum;
    Transform[] m_buttons = new Transform[Enum.GetNames(typeof(ItemEnum)).Length];
    private void Start()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            m_buttons[i] = transform.Find("Button (" + i + ")");
        }
    }
    void Update()
    {
        if (ItemManage.Instance.itemList[ItemEnum.Chicken] == 0)
        {
            m_buttons[0].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[0].gameObject.SetActive(true);
        }
    }
}
