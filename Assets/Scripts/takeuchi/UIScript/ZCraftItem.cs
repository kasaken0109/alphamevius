using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZCraftItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Text m_itemNameText;
    [SerializeField] int m_itemID;
    Image m_buttonImage;
    ZCraftGuide m_craftGuide;
    void Start()
    {
        m_itemNameText.text = NewItemManager.Instance.GetName(m_itemID);
        m_buttonImage = GetComponent<Image>();
    }
    public void SetItemID(int itemID)
    {
        m_itemID = itemID;
        m_itemNameText.text = NewItemManager.Instance.GetName(itemID);
    }
    public void SetCraftGuide(ZCraftGuide guide)
    {
        m_craftGuide = guide;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        m_buttonImage.color = new Color(0.6f, 0.6f, 0.6f);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        m_craftGuide.SetData(m_itemID);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        m_buttonImage.color = Color.white;
    }
}
