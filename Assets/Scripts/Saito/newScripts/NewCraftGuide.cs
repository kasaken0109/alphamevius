using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class NewCraftGuide : MonoBehaviour
{
    [SerializeField] Image[] m_image;
    [SerializeField] Text[] m_guideText;
    MaterialType[] m_needMaterials;
    int[] m_idList = new int[6];
    int[] m_needMaterialNumbers = new int[6];
    public void OpenGuide(int ID)
    {
        gameObject.SetActive(true);
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_idList[i] = 0;
            m_needMaterialNumbers[i] = 0;
        }
        m_needMaterials = NewItemManager.Instance.GetNeedMaterialItems(ID);
        var result = m_needMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            m_idList[index] = NewItemManager.Instance.GetMaterialId(item);
            m_needMaterialNumbers[index] = m_needMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_image[i].sprite = NewItemManager.Instance.GetSprite(m_idList[i]);
            int b = m_needMaterialNumbers[i];
            if (b > 0) 
            {
                m_guideText[i].text ="×"+ b.ToString();
            }
            else
            {
                m_guideText[i].text ="";
            }
        }
        //m_image.sprite = NewItemManager.Instance.GetSprite(ID);
        //m_guideText.text = NewItemManager.Instance.GetGuideText(ID);
        
    }
    public void CloseGuide()
    {
        gameObject.SetActive(false);
    }
}
