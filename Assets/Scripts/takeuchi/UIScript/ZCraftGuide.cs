using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ZCraftGuide : MonoBehaviour
{
    // 0:作成アイテム、1:必要素材１、2:必要素材２、
    [SerializeField] Image[] m_craftItemIcon;
    [SerializeField] Text[] m_craftItemText;
    [SerializeField] GameObject m_arrowIcon;
    MaterialType[] m_needMaterials;
    int[] m_idList = new int[2];
    int[] m_needMaterialNumbers = new int[2];
    void Start()
    {
        ResetData();
    }
    public void ResetData()
    {
        for (int i = 0; i < 3; i++)
        {
            m_craftItemIcon[i].sprite = NewItemManager.Instance.GetSprite(0);
            m_craftItemText[i].text = "";
        }
        m_arrowIcon.SetActive(false);
    }
    public void SetData(int itemID)
    {
        m_arrowIcon.SetActive(true);
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_idList[i] = 0;
            m_needMaterialNumbers[i] = 0;
        }
        m_needMaterials = NewItemManager.Instance.GetNeedMaterialItems(itemID);
        var result = m_needMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            m_idList[index] = NewItemManager.Instance.GetMaterialId(item);
            m_needMaterialNumbers[index] = m_needMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_craftItemIcon[i + 1].sprite = NewItemManager.Instance.GetSprite(m_idList[i]);
            int b = m_needMaterialNumbers[i];
            if (b > 0)
            {
                m_craftItemText[i + 1].text = NewItemManager.Instance.GetName(m_idList[i]) + "×" + b.ToString();
            }
            else
            {
                m_craftItemText[i + 1].text = "";
            }
        }
        NewCraftManager.Instance.SetTargetID(itemID);
    }
}
