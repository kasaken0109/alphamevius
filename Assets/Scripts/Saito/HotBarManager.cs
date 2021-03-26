using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class HotBarManager : MonoBehaviour
{
    public static HotBarManager Instance { get; private set; }
    //List<ItemEnum> m_hotBarList = new List<ItemEnum>();
    List<ItemBaseMain> m_hotBarList = new List<ItemBaseMain>();
    [SerializeField] Text[] texts;
    public void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        
    }
    public void SetHotBar(ItemBaseMain type)
    {
        if (m_hotBarList.Count < 8 && ItemManage.Instance.states[(int)type.GetItemType()] != ItemStates.MaterialItem)
        {
            m_hotBarList.Add(type);
            Debug.Log("ホットバーに" + type.ToString() + "を加えました");
            ChangeHotBarText();
        }
        else
        {
            Debug.Log("ホットバーに加えることが出来ません");
        }
    }
    public void ChangeHotBarText()
    {
        bool[] check = new bool[m_hotBarList.Count];
        for (int i = 0; i < m_hotBarList.Count; i++)
        {
            if (ItemManage.Instance.itemList[m_hotBarList[i].GetItemType()] > 0)
            {
                texts[i].text = m_hotBarList[i].GetItemType().ToString() + ItemManage.Instance.itemList[m_hotBarList[i].GetItemType()].ToString();
                check[i] = false;
            }
            else
            {
                check[i] = true;
            }
        }
        for (int i = m_hotBarList.Count - 1; i > 0; i--)
        {
            
        }
    }
    public void UseHotBarItem(int ID)
    {
        if (ItemManage.Instance.states[(int)m_hotBarList[ID].GetItemType()] == ItemStates.HaveItem)
        {
            ItemManage.Instance.EquipItem((HaveItem)m_hotBarList[ID]);
        }
        else if (m_hotBarList[ID].GetItemType() == ItemEnum.Bridge)
        {
            CreateBridge.Instance.BridgeCreate();
        }
        else if (ItemManage.Instance.UseItem(m_hotBarList[ID].GetItemType()))
        {
            if (ItemManage.Instance.states[(int)m_hotBarList[ID].GetItemType()] == ItemStates.UseItem)
            {
                if (m_hotBarList[ID].GetItemType() == ItemEnum.Trap)
                {
                    m_hotBarList[ID].UseTrap();
                }
                else
                {
                    m_hotBarList[ID].UseHeal();
                }
            }
        }
    }
}
