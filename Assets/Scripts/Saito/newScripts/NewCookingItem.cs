using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCookingItem : MonoBehaviour, IPointerClickHandler
{
    int ID;
    [SerializeField] Image image;
    [SerializeField] Text haveNumber;

    public void ChangeImage(int ID)
    {
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);

    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

    }
}