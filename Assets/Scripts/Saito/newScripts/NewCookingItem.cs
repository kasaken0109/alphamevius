using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCookingItem : MonoBehaviour, IPointerClickHandler
{
    int ID = 0;
    [SerializeField] Image image;
    [SerializeField] NewItem item;
    
    private void Start()
    {
        if (!item)
        {
            return;
        }
        image.sprite = item.GetSprite();
        ID = item.GetID();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ID > 0)
        {
            NewInventoryManager.Instance.OpenCookingGuide(ID);
        }
    }
}