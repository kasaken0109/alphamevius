using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class NewRecycleGuide : MonoBehaviour
{
    [SerializeField] Image[] m_image;
    [SerializeField] Text[] m_guideText;
    MaterialType[] m_recycleMaterials;
    int[] m_idList = new int[6];
    int[] m_recycleMaterialNumbers = new int[6];
    public void OpenGuide(int ID)
    {
        gameObject.SetActive(true);
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_idList[i] = 0;
            m_recycleMaterialNumbers[i] = 0;
        }
        m_recycleMaterials = NewItemManager.Instance.GetRecycleMaterialItems(ID);
        var result = m_recycleMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            m_idList[index] = NewItemManager.Instance.GetMaterialId(item);
            m_recycleMaterialNumbers[index] = m_recycleMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int i = 0; i < m_idList.Length; i++)
        {
            m_image[i].sprite = NewItemManager.Instance.GetSprite(m_idList[i]);
            int b = m_recycleMaterialNumbers[i];
            if (b > 0)
            {
                m_guideText[i].text = "×" + b.ToString();
            }
            else
            {
                m_guideText[i].text = "";
            }
        }
        //m_image.sprite = NewItemManager.Instance.GetSprite(ID);
        //m_guideText.text = NewItemManager.Instance.GetGuideText(ID);
        NewCraftManager.Instance.SetTargetID(ID);
    }
    public void CloseGuide()
    {
        gameObject.SetActive(false);
    }
}
