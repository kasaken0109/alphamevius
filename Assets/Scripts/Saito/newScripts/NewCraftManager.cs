﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewCraftManager : MonoBehaviour
{
    public static NewCraftManager Instance { get; private set; }
    public int m_level { get; private set; }
    public int m_exp { get; private set; }
    [SerializeField] int[] needEXPList;
    int targetID = 0;
    NewItemManager itemManager;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        itemManager = NewItemManager.Instance;
    }
    public void SetTargetID(int ID)
    {
        targetID = ID;
    }
    public void OnClickCraft()
    {
        if (m_level < itemManager.GetItem(targetID).GetCraftLevel())
        {
            Debug.Log("レベル不足");
            return;
        }
        MaterialType[] needMaterials = itemManager.GetNeedMaterialItems(targetID); ;
        int[] idList = new int[6];
        int[] needMaterialNumbers = new int[6];
        var result = needMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            idList[index] = itemManager.GetMaterialId(item);
            needMaterialNumbers[index] = needMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int j = 0; j < idList.Length; j++)
        {
            if (itemManager.HaveItemNumber(idList[j]) < needMaterialNumbers[j])
            {
                MessgaeManager.ViweMessage("素材が足りません");
                Debug.Log("不足");
                return;
            }
        }
        itemManager.AddItem(targetID, 1);
        for (int a = 0; a < idList.Length; a++)
        {
            itemManager.SubItem(idList[a], needMaterialNumbers[a]);
        }
        MessgaeManager.ViweMessage(NewItemManager.Instance.GetName(targetID) + "を作成した！", targetID);
        Debug.Log("作成");
        EXPGet(2);
    }
    public void OnClickRecycle()
    {
        if (itemManager.HaveItemNumber(targetID) > 0)
        {
            itemManager.SubItem(targetID, 1);
            foreach (var item in itemManager.GetRecycleMaterialItems(targetID))
            {
                itemManager.AddItem(itemManager.GetMaterialId(item), 1);
            }
            Debug.Log("分解");
            EXPGet(4);
            NewInventoryManager.Instance.RecycleListUpdate();
        }
    }
    public void EXPGet(int exp)
    {
        m_exp += exp;
        if (m_level < needEXPList.Length)
        {
            if (needEXPList[m_level] <= m_exp)
            {
                m_level++;
                Debug.Log("レベルアップ！" + m_level);
            }
        }
    }
}
