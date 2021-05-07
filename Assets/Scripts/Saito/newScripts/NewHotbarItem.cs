using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHotbarItem : MonoBehaviour
{
    int ID;
    bool check;
    [SerializeField] Image image;
    [SerializeField] Text haveNumber;
    [SerializeField] int hotbarID;
    [SerializeField] GameObject hotbarMark;
    int m_equipmentID = 0;
    public void ChangeImage(int ID)
    {
        this.ID = ID; 
        if (m_equipmentID == ID && ID != 0)
        {
            hotbarMark.SetActive(true);
        }
        else
        {
            hotbarMark.SetActive(false);
        }
        image.sprite = NewItemManager.Instance.GetSprite(ID);
    }
    public int GetID(){ return ID; }
    public void SetEquipmentMark(int equipmentID)
    {
        m_equipmentID = equipmentID;
        if (equipmentID == 0)
        {
            hotbarMark.SetActive(false);
        }
        else if (ID == equipmentID)
        {
            hotbarMark.SetActive(true);
        }
        else
        {
            hotbarMark.SetActive(false);
        }
    }
    public void ChangeGray()
    {
        image.color = new Color(0.5f, 0.5f, 0.5f);
        hotbarMark.SetActive(false);
    }
    public void ChangeNomaleColor()
    {
        image.color = new Color(1, 1, 1);
    }
}
