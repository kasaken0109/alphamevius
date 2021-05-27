using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
public class NewHotbarItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    int ID;
    [SerializeField] Image image;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Text haveNumber;
    [SerializeField] int hotbarID;
    [SerializeField] GameObject hotbarMark;
    int m_equipmentID = 0;
    [SerializeField] GameObject item;
    GameObject dragItem;
    Transform canvasTransform;
    private void Start()
    {

        canvasTransform = GameObject.Find("Canvas").transform;
    }
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
        if (ID == 0)
        {
            image.sprite = defaultSprite;
        }
        else
        {
            image.sprite = NewItemManager.Instance.GetSprite(ID);
        }
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
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (ID != 0)
        {
            image.color = new Color(0.6f, 0.6f, 0.6f);
        }
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (NewItemManager.Instance.HaveItemNumber(GetID()) > 0)
        {
            ChangeNomaleColor();
        }
        else if(ID != 0)
        {
            ChangeGray();
        }
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (ID == 0)
        {
            dragItem.transform.position = new Vector2(3000, 2000);
        }
        else
        {
            dragItem.transform.position = eventData.position;
        }
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        dragItem = Instantiate(item, canvasTransform);
        dragItem.GetComponent<Image>().sprite = image.sprite;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (dragItem)
        {
            Destroy(dragItem);
        }
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        var result = results.Where(i => i.gameObject.CompareTag("Hotbar")).FirstOrDefault();        
        if (result.gameObject && ID != 0)
        {
            NewHotbarItem item = result.gameObject.GetComponent<NewHotbarItem>();
            if (item.hotbarID != hotbarID)
            {
                item.ChangeImage(ID);
                ChangeImage(0);
            }
        }
        else
        {
            ChangeImage(0);
        }
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ID > 0)
        {
            NewItemEffectManager.Instance.SetUse(GetID());
        }
    }
}
