﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewRecycleItem : MonoBehaviour,  IPointerClickHandler
{
    int ID = 0;
    int check;
    [SerializeField] Image image;
    [SerializeField] Text haveNumber;
    private void Awake()
    {
        haveNumber.text = "";
    }
    private void Start()
    {
        image.sprite = NewItemManager.Instance.GetSprite(ID);
    }
    public void ChangeImage(int ID)
    {
        check = NewItemManager.Instance.HaveItemNumber(ID);
        if (check <= 0)
        {
            haveNumber.text = "";
            if (ID > 0)
            {
                image.sprite = NewItemManager.Instance.GetSprite(0);
                NewInventoryManager.Instance.RecycleListUpdate();
                return;
            }
        }
        else
        {
            haveNumber.text = check.ToString();
        }
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
       
    }
    
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ID > 0)
        {
            NewInventoryManager.Instance.OpenRecycleGuide(ID);
        }
    }


}
