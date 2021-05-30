using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZCraftPanelControl : MonoBehaviour
{
    [SerializeField] ZCraftGuide m_craftGuide;
    [SerializeField] RectTransform[] m_craftPage; // 0は自身
    [SerializeField] ZCraftItem[] m_craftItemButtons;
    void Start()
    {
        foreach (var guide in m_craftItemButtons)
        {
            guide.SetCraftGuide(m_craftGuide);
        }
        CloseCraft();
    }
    public void OnClickOpenCraft()
    {
        m_craftPage[0].localPosition = new Vector2(0, 0);
        m_craftPage[1].localPosition = new Vector2(0, 0);
    }
    public void CloseCraft()
    {
        m_craftGuide.ResetData();
        foreach (var page in m_craftPage)
        {
            page.localPosition = new Vector2(2000, 2000);
        }
    }
    public void PageUpdate()
    {
        foreach (var item in m_craftItemButtons)
        {
            item.ColorSet();
        }
    }
    public void OnClickOpenPage(int page)
    {
        SoundManager.Instance.PlayUISound();
        for (int i = 1; i < m_craftPage.Length; i++)
        {
            if (page == i)
            {
                m_craftPage[i].localPosition = new Vector2(0, 0);
            }
            else
            {
                m_craftPage[i].localPosition = new Vector2(2000, 2000);
            }
        }
    }
}
