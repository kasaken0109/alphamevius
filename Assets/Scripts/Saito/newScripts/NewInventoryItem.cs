using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class NewInventoryItem : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler ,IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    int ID = 0;
    int check;
    [SerializeField] Image image;
    [SerializeField] GameObject guide;
    [SerializeField] Image guideImage;
    [SerializeField] Text[] texts;
    [SerializeField] Text haveNumber;
    [SerializeField] GameObject item;
    GameObject dragItem;
    Transform canvasTransform;
    bool checkTool;
    private void Awake()
    {
        haveNumber.text = "";
    }
    private void Start()
    {
        image.sprite = NewItemManager.Instance.GetSprite(ID);
        canvasTransform = GameObject.Find("Canvas").transform;
    }
    public void ChangeImage(int ID)
    {
        check = NewItemManager.Instance.HaveItemNumber(ID);
        if (check <= 0)
        {
            haveNumber.text = "";
            if (ID > 0)
            {
                NewInventoryManager.Instance.ItemListUpdate();
                return;
            }
        }
        else
        {
            haveNumber.text = check.ToString();
        }
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
        if (NewItemManager.Instance.GetToolType(ID)== ToolType.None)
        {
            checkTool = false;
        }
        else
        {
            checkTool = true;
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        //ViewGuide();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //CloseGuide();
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!checkTool)
        {
            return;
        }
        dragItem.transform.position = eventData.position;
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!checkTool)
        {
            return;
        }
        dragItem = Instantiate(item, canvasTransform);
        dragItem.GetComponent<Image>().sprite = image.sprite;
    }
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (!checkTool)
        {
            return;
        }
        if (dragItem)
        {
            Destroy(dragItem);
        }
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        var result = results.Where(i => i.gameObject.CompareTag("Hotbar")).FirstOrDefault();
        if (result.gameObject)
        {
            result.gameObject.GetComponent<NewHotbarItem>().ChangeImage(ID);
        }
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ID > 0) 
        { 
            NewInventoryManager.Instance.OpenItemGuide(ID);
        }
        //NewInventoryManager.Instance.OpenCraftGuide(ID);
        //NewInventoryManager.Instance.OpenRecycleGuide(ID);
        //NewInventoryManager.Instance.OpenCookingGuide(ID);
    }
    public void ViewGuide()
    {
        guide.SetActive(true);
    }
    public void CloseGuide()
    {
        guide.SetActive(false);
    }
    public int GetID() { return ID; }
}
