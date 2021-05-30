using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

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
        SoundManager.Instance.PlayUISound();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ColorSet();
    }
    public void ColorSet()
    {
        if (IsCraftCheck())
        {
            m_buttonImage.color = Color.white;
        }
        else
        {
            m_buttonImage.color = new Color(0.4f, 0.4f, 0.4f);
        }
    }
    public bool IsCraftCheck()
    {
        MaterialType[] needMaterials = NewItemManager.Instance.GetNeedMaterialItems(m_itemID); ;
        int[] idList = new int[3];
        int[] needMaterialNumbers = new int[3];
        var result = needMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            idList[index] = NewItemManager.Instance.GetMaterialId(item);
            needMaterialNumbers[index] = needMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int j = 0; j < idList.Length; j++)
        {
            if (NewItemManager.Instance.HaveItemNumber(idList[j]) < needMaterialNumbers[j])
            {
                return false;
            }
        }
        return true;
    }
}
