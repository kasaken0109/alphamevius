using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewInventoryGuide : MonoBehaviour
{
    [SerializeField] Image m_image;
    [SerializeField] Text m_itemNameText;
    [SerializeField] Text m_guideText;
    [SerializeField] GameObject m_button;
    [SerializeField] Text m_buttonText;
    int ID;
    public void OpenGuide(int ID)
    {
        gameObject.SetActive(true);
        this.ID = ID;
        m_image.sprite = NewItemManager.Instance.GetSprite(ID);
        m_itemNameText.text = NewItemManager.Instance.GetName(ID);
        m_guideText.text = NewItemManager.Instance.GetGuideText(ID);
        if (ToolType.None == NewItemManager.Instance.GetToolType(ID))
        {
            m_button.SetActive(false);
        }
        else
        {
            m_button.SetActive(true);
            if (NewItemManager.Instance.GetToolCheck(ID))
            {
                m_buttonText.text = "装備";
            }
            else
            {
                m_buttonText.text = "使用";
            }
        }
    }
    public void CloseGuide()
    {
        gameObject.SetActive(false);
    }
    public void OnClickUseItem() 
    {
        if (NewItemManager.Instance.HaveItemNumber(ID) > 0)
        {
            NewItemEffectManager.Instance.SetUse(ID);
        }
    }
}
