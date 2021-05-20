using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZInventoryTools : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject m_frame;
    [SerializeField] GameObject m_eMark;
    [SerializeField] RectTransform m_namePlate;
    [SerializeField] Text m_nameText;
    int m_itemID;
    [SerializeField] Image m_image;
    ZRecycleItem m_recycleItem;
    private void Start()
    {
        m_eMark.SetActive(false);
        m_namePlate.localPosition = new Vector2(0, 2000);
    }
    public void SetRecycle(ZRecycleItem recycleItem)
    {
        m_recycleItem = recycleItem;
        m_recycleItem.SetInventory(this);
        m_recycleItem.SetItemID(0);
    }
    public void SetItem(int itemID)
    {
        m_itemID = itemID;
        if (itemID > 0)
        {
            m_frame.SetActive(false);
            m_eMark.SetActive(false);
            m_image.sprite = NewItemManager.Instance.GetSprite(itemID);
            string name = NewItemManager.Instance.GetName(itemID);
            m_nameText.text = name;
            m_namePlate.sizeDelta = new Vector2(60 + name.Length * 10, 30);
            m_recycleItem.SetItemID(itemID);
        }
        else
        {
            ResetItem();
            m_recycleItem.SetItemID(0);
        }
    }
    public int GetItemID() { return m_itemID; }
    public void ResetItem()
    {
        m_itemID = 0; 
        m_frame.SetActive(true);
        m_eMark.SetActive(false);
        m_image.sprite = NewItemManager.Instance.GetSprite(0);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (m_itemID > 0)
        {
            m_image.color = new Color(0.8f, 0.8f, 0.8f);
            m_namePlate.localPosition = new Vector2(0, 43);
        }
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        NewItemEffectManager.Instance.SetUse(m_itemID);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        m_image.color = Color.white;
        m_namePlate.localPosition = new Vector2(0, 2000);
    }
}
