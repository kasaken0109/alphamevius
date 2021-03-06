using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconGuideView : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text nameText;
    [SerializeField] GameObject guide;
    [SerializeField] Image thisImage;
    int id;
    void Start()
    {
        guide.SetActive(false);
    }
    public void SetImage(Sprite sprite,int itemID)
    {
        thisImage.sprite = sprite;
        nameText.text = NewItemManager.Instance.GetName(itemID);
        id = itemID;
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (id == 0)
        {
            return;
        }
        guide.SetActive(true);
        thisImage.color = new Color(0.6f, 0.6f, 0.6f);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        guide.SetActive(false);
        thisImage.color = new Color(1, 1, 1);
    }
}
