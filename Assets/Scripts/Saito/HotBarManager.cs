using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class HotBarManager : MonoBehaviour
{
    public static HotBarManager Instance { get; private set; }
    List<ItemEnum> m_hotBarList = new List<ItemEnum>();
    [SerializeField] Text[] texts;
    public void Awake()
    {
        Instance = this;
    }
    
    public void SetHotBar(int ID)
    {
        if (m_hotBarList.Count < 8 && ItemManage.Instance.states[(int)ID] != ItemStates.MaterialItem)
        {
            ItemEnum type = (ItemEnum)Enum.ToObject(typeof(ItemEnum), ID);
            m_hotBarList.Add(type);
            Debug.Log("ホットバーに" + type.ToString() + "を加えました");
            for (int i = 0; i < m_hotBarList.Count; i++)
            {
                texts[i].text = m_hotBarList[i].ToString();
            }
        }
        else
        {
            Debug.Log("ホットバーに加えることが出来ません");
        }
    }
}
