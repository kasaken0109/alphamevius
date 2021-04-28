using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewRecycleItem : MonoBehaviour,  IPointerClickHandler
{
    int ID = 0;
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
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
        haveNumber.text = NewItemManager.Instance.HaveItemNumber(ID).ToString();
    }
    
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

    }

    
}
