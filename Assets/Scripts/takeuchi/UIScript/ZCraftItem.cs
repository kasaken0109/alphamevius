using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class ZCraftItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Text m_itemNameText;
    [SerializeField] int m_itemID;
    [SerializeField] GameObject m_guide;
    [SerializeField] Text m_guideText;
    Image m_buttonImage;
    ZCraftGuide m_craftGuide;
    void Start()
    {
        m_itemNameText.text = NewItemManager.Instance.GetName(m_itemID);
        m_guideText.text = NewItemManager.Instance.GetGuideText(m_itemID);
        m_buttonImage = GetComponent<Image>();
        m_guide.SetActive(false);
    }
    public void SetItemID(int itemID)
    {
        m_itemID = itemID;
        m_itemNameText.text = NewItemManager.Instance.GetName(itemID);
        m_guideText.text = NewItemManager.Instance.GetGuideText(itemID);
    }
    public void SetCraftGuide(ZCraftGuide guide)
    {
        m_craftGuide = guide;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        m_buttonImage.color = new Color(0.6f, 0.6f, 0.6f);
        m_guide.SetActive(true);
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        m_craftGuide.SetData(m_itemID);
        SoundManager.Instance.PlayUISound();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        ColorSet();
        m_guide.SetActive(false);
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
        int[] idList = new int[2];
        int[] needMaterialNumbers = new int[2];
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
