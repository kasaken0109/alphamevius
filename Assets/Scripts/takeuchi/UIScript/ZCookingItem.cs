using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ZCookingItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Text m_itemNameText;
    [SerializeField] int m_itemID;
    [SerializeField] Image m_buttonImage;
    ZCookingGuid m_cookingGuide;
    void Start()
    {
        m_itemNameText.text = NewItemManager.Instance.GetName(m_itemID);
    }
    public void SetItemID(int itemID)
    {
        m_itemID = itemID;
        m_itemNameText.text = NewItemManager.Instance.GetName(itemID);
    }
    public void SetCookingGuid(ZCookingGuid cookingGuid)
    {
        m_cookingGuide = cookingGuid;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        m_buttonImage.color = new Color(0.6f, 0.6f, 0.6f);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        m_cookingGuide.SetData(m_itemID);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        m_buttonImage.color = Color.white;
    }
}
