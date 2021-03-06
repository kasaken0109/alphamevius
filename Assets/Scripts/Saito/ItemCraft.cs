using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemCraft : MonoBehaviour
{
    bool frag = true;
    bool craftFrag = true;
    public ItemEnum craftItem;
    public List<ItemEnum> craftData = new List<ItemEnum>();
    
    
    public void ItemCrafting()
    {
        int count = 0;
        int temp = 0;
        while (frag)
        {
            count = craftData.Count(i => craftData[temp] == i);
            if (ItemManage.Instance.itemList[craftData[temp]] < count)
            {
                craftFrag = false;
                frag = false;
            }
            else
            {
                temp += count;
            }
            if (craftData.Count == temp)
            {
                frag = false;
            }
        }
        if (craftFrag)
        {
            if ((int)craftItem >= (int)ItemEnum.AluminiumKnife)
            {
                if (ItemManage.Instance.itemList[craftItem] == 1)
                {
                    Debug.Log("複数もてません");
                }
                else if(craftItem == ItemEnum.Bridge || craftItem == ItemEnum.Fire)
                {
                    EventItem item = new EventItem(craftItem);
                    Debug.Log(craftItem.ToString() + "を作成した");
                    ItemManage.Instance.m_playerExp++;
                    ItemManage.Instance.SetItem(item);
                    UseItem m_endMaterial = new UseItem(ItemEnum.EndMaterial);
                    ItemManage.Instance.SetItem(m_endMaterial, ItemManage.Instance.m_playerLevel);
                    for (int i = 0; i < craftData.Count; i++)
                    {
                        ItemManage.Instance.itemList[craftData[i]]--;
                    }
                }
                else
                {
                    HaveOne item = new HaveOne(craftItem);
                    Debug.Log(craftItem.ToString() + "を作成した");
                    ItemManage.Instance.m_playerExp++;
                    ItemManage.Instance.SetItem(item);
                    UseItem m_endMaterial = new UseItem(ItemEnum.EndMaterial);
                    ItemManage.Instance.SetItem(m_endMaterial, ItemManage.Instance.m_playerLevel);
                    for (int i = 0; i < craftData.Count; i++)
                    {
                        ItemManage.Instance.itemList[craftData[i]]--;
                    }
                }
            }
            else
            {
                UseItem item = new UseItem(craftItem);
                Debug.Log(craftItem.ToString() + "を作成した");
                ItemManage.Instance.m_playerExp++;
                ItemManage.Instance.SetItem(item, ItemManage.Instance.m_playerLevel);
                UseItem m_endMaterial = new UseItem(ItemEnum.EndMaterial);
                ItemManage.Instance.SetItem(m_endMaterial, ItemManage.Instance.m_playerLevel);
                for (int i = 0; i < craftData.Count; i++)
                {
                    ItemManage.Instance.itemList[craftData[i]]--;
                }
            }
        }
        else
        {
            Debug.Log("素材が足りません");
        }

    }
}
