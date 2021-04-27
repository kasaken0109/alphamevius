using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCraftItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    int ID;
    bool check;
    [SerializeField] Image image;
    [SerializeField] GameObject guide;
    [SerializeField] Image guideImage;
    [SerializeField] Text[] texts;
    [SerializeField] Text haveNumber;
    [SerializeField] GameObject item;
    
    public void ChangeImage(int ID)
    {
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
        
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ViewGuide();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        CloseGuide();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

    }
    
    public void ViewGuide()
    {
        guide.SetActive(true);
    }
    public void CloseGuide()
    {
        guide.SetActive(false);
    }
}
