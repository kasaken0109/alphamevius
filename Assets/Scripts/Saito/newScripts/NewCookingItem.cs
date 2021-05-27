using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCookingItem : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
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
            TargetMark.Instance.TargetSet(gameObject.GetComponent<RectTransform>());
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0.6f, 0.6f, 0.6f);
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1f, 1f, 1f);
    }
}