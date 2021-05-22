using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ZCookingGuid : MonoBehaviour
{
    // 0:作成アイテム、1:入手素材１、2:入手素材２、3:必要素材１、4:必要素材２、5:必要素材３、
    [SerializeField] Image[] m_materialItemIcon;
    [SerializeField] Text[] m_materialItemText;
    [SerializeField] GameObject m_arrowIcon;
    [SerializeField] ZCookingItem[] m_cookingItems;
    MaterialType[] m_materials;
    int[] m_idList = new int[2];
    int[] m_materialNumbers = new int[2];
    int[] m_idList2 = new int[3];
    int[] m_materialNumbers2 = new int[3];
    void Start()
    {
        ResetData();
        m_cookingItems.ToList().ForEach(i => i.SetCookingGuid(this));
    }
    public void PageUpdate()
    {
        m_cookingItems.ToList().ForEach(i => i.ColorSet());
    }
    public void ResetData()
    {
        for (int i = 0; i < 6; i++)
        {
            m_materialItemIcon[i].sprite = NewItemManager.Instance.GetSprite(0);
            m_materialItemText[i].text = "";
        }
        m_arrowIcon.SetActive(false);
    }
    public void SetData(int itemID)
    {
        m_arrowIcon.SetActive(true);
        m_materialItemIcon[0].sprite = NewItemManager.Instance.GetSprite(itemID);
        m_materialItemText[0].text = NewItemManager.Instance.GetName(itemID);
        ZInventoryManager.Instance.ViewMaterialReset();
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_idList[i] = 0;
            m_materialNumbers[i] = 0;
        }
        m_materials = NewItemManager.Instance.GetRecycleMaterialItems(itemID);
        var result = m_materials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            m_idList[index] = NewItemManager.Instance.GetMaterialId(item);
            m_materialNumbers[index] = m_materials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_materialItemIcon[i + 1].sprite = NewItemManager.Instance.GetSprite(m_idList[i]);
            int b = m_materialNumbers[i];
            if (b > 0)
            {
                m_materialItemText[i + 1].text = NewItemManager.Instance.GetName(m_idList[i]) + "×" + b.ToString();
                ZInventoryManager.Instance.ViewGetMaterial(m_idList[i], b);
            }
            else
            {
                m_materialItemText[i + 1].text = "";
            }
        }
        for (int i = 0; i < m_idList2.Length; i++)
        {
            m_idList2[i] = 0;
            m_materialNumbers2[i] = 0;
        }
        m_materials = NewItemManager.Instance.GetNeedMaterialItems(itemID);
        result = m_materials.ToList().Distinct();
        index = 0;
        foreach (var item in result)
        {
            m_idList2[index] = NewItemManager.Instance.GetMaterialId(item);
            m_materialNumbers2[index] = m_materials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList2.Length; i++)
        {
            m_materialItemIcon[i + 3].sprite = NewItemManager.Instance.GetSprite(m_idList2[i]);
            int b = m_materialNumbers2[i];
            if (b > 0)
            {
                m_materialItemText[i + 3].text = NewItemManager.Instance.GetName(m_idList2[i]) + "×" + b.ToString();
                ZInventoryManager.Instance.ViewGetMaterial(m_idList2[i], b);
            }
            else
            {
                m_materialItemText[i + 3].text = "";
            }
        }
        NewCraftManager.Instance.SetTargetID(itemID);
    }
    public void Cooking()
    {
        //ZInventoryManager.Instance.ItemGet(m_idList[1], m_materialItemIcon[1].GetComponent<RectTransform>().position, m_idList[2], m_materialItemIcon[2].GetComponent<RectTransform>().position);
    }
}
