using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZInventoryHaveItem : MonoBehaviour
{
    [SerializeField] int m_itemID = 0;
    [SerializeField] Image m_itemIcon;
    [SerializeField] Text m_haveNumberText;
    [SerializeField] Text m_changeNumberText;
    void Start()
    {
        m_itemIcon.sprite = NewItemManager.Instance.GetSprite(m_itemID);
        DataUpdate();
        m_changeNumberText.text = "";
    }
    public void SetItemID(int id)
    {
        m_itemID = id;
        m_itemIcon.sprite = NewItemManager.Instance.GetSprite(m_itemID);
        DataUpdate();
    }
    public int GetItemID() { return m_itemID; }
    public void DataUpdate()
    {
        int i = NewItemManager.Instance.GetItem(m_itemID).GetHaveNumber();
        m_haveNumberText.text = "×" + i.ToString();
        if (i > 0)
        {
            m_itemIcon.color = Color.white;
        }
        else
        {
            m_itemIcon.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
    public void CraftCheck(int needNumber)
    {
        m_changeNumberText.text = '-' + needNumber.ToString();
        m_changeNumberText.color = Color.red;
    }
    public void RecycleCheck(int getNumber)
    {
        m_changeNumberText.text = '+' + getNumber.ToString();
        m_changeNumberText.color = Color.blue;
    }
    public void ClearText()
    {
        m_changeNumberText.text = "";
    }
}
