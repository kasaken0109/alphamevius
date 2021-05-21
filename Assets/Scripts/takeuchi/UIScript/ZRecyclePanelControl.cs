using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZRecyclePanelControl : MonoBehaviour
{
    [SerializeField] ZRecycleGuide m_recycleGuide;
    [SerializeField] RectTransform m_recyclePage;
    [SerializeField] ZRecycleItem[] m_recycleItemButtons;
    private void Start()
    {
        foreach (var item in m_recycleItemButtons)
        {
            item.SetData(m_recycleGuide);
        }
        ZInventoryManager.Instance.SetRecycleTools(m_recycleItemButtons);
        CloseRecycle();
    }
    public void OnClickOpenRecycle()
    {
        m_recyclePage.localPosition = new Vector2(0, 0);
    }
    public void CloseRecycle()
    {
        m_recycleGuide.ResetData();
        m_recyclePage.localPosition = new Vector2(2000, 2000);
    }
    public void PickResetAll()
    {
        foreach (var item in m_recycleItemButtons)
        {
            item.PickReset();
        }
    }
}
