using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZRecycleItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject m_eMark;
    [SerializeField] RectTransform m_namePlate;
    [SerializeField] Text m_nameText;
    [SerializeField] Image m_image;
    int m_itemID;
    ZRecycleGuide m_recycleGuide;
    ZInventoryTools m_inventoryTools;
    public void SetData(ZRecycleGuide recycleGuide)
    {
        m_recycleGuide = recycleGuide;
        m_image.sprite = NewItemManager.Instance.GetSprite(0);
        m_namePlate.localPosition = new Vector2(0, 2000);
        m_eMark.SetActive(false);
    }
    public void SetInventory(ZInventoryTools inventory)
    {
        m_inventoryTools = inventory;
    }
    public void SetItemID(int itemID)
    {
        gameObject.SetActive(true);
        m_itemID = itemID;
        if (itemID > 0)
        {
            m_eMark.SetActive(false);
            m_image.sprite = NewItemManager.Instance.GetSprite(itemID);
            string name = NewItemManager.Instance.GetName(itemID);
            m_nameText.text = name;
            m_namePlate.sizeDelta = new Vector2(60 + name.Length * 10, 30);
        }
        else
        {
            m_eMark.SetActive(false);
            m_image.sprite = NewItemManager.Instance.GetSprite(0);
            m_itemID = 0;
            gameObject.SetActive(false);
        }
    }
    public void EquipmentSet()
    {
        m_eMark.SetActive(true);
    }
    public void EquipmentOut()
    {
        m_eMark.SetActive(false);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (m_itemID > 0)
        {
            m_image.color = new Color(0.8f, 0.8f, 0.8f);
            m_namePlate.localPosition = new Vector2(0, 55);
        }
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (m_itemID > 0)
        {
            m_recycleGuide.SetData(m_itemID, m_inventoryTools);
        }
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        m_image.color = Color.white;
        m_namePlate.localPosition = new Vector2(0, 2000);
    }
}
