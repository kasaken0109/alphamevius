using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ZRecycleGuide : MonoBehaviour
{
    // 0:分解アイテム、1:入手素材１、2:入手素材２、3:入手素材３
    [SerializeField] Image[] m_recycleItemIcon;
    [SerializeField] Text[] m_recycleItemText;
    [SerializeField] GameObject m_arrowIcon;
    MaterialType[] m_getMaterials;
    int[] m_idList = new int[3];
    int[] m_getMaterialNumbers = new int[3];
    ZInventoryTools m_target;
    void Start()
    {
        ResetData();
    }
    public void ResetData()
    {
        for (int i = 0; i < 4; i++)
        {
            m_recycleItemIcon[i].sprite = NewItemManager.Instance.GetSprite(0);
            m_recycleItemText[i].text = "";
        }
        m_target = null;
        m_arrowIcon.SetActive(false);
    }
    public void SetData(int itemID , ZInventoryTools target)
    {
        m_arrowIcon.SetActive(true);
        m_target = target;
        m_recycleItemIcon[0].sprite = NewItemManager.Instance.GetSprite(itemID);
        m_recycleItemText[0].text = NewItemManager.Instance.GetName(itemID);
        ZInventoryManager.Instance.ViewMaterialReset();
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_idList[i] = 0;
            m_getMaterialNumbers[i] = 0;
        }
        m_getMaterials = NewItemManager.Instance.GetRecycleMaterialItems(itemID);
        var result = m_getMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            m_idList[index] = NewItemManager.Instance.GetMaterialId(item);
            m_getMaterialNumbers[index] = m_getMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_recycleItemIcon[i + 1].sprite = NewItemManager.Instance.GetSprite(m_idList[i]);
            int b = m_getMaterialNumbers[i];
            if (b > 0)
            {
                m_recycleItemText[i + 1].text = NewItemManager.Instance.GetName(m_idList[i]) + "×" + b.ToString();
                ZInventoryManager.Instance.ViewGetMaterial(m_idList[i], b);
            }
            else
            {
                m_recycleItemText[i + 1].text = "";
            }
        }
        NewCraftManager.Instance.SetTargetID(itemID);
    }
    public void OnClickRecycle()
    {
        if (!m_target)
        {
            return;
        }
        m_target.SetItem(0);
        NewCraftManager.Instance.OnClickRecycle();
        ResetData();
        ZInventoryManager.Instance.ViewMaterialReset();
    }
}
