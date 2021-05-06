using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewCraftItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    int ID = 0;
    bool check;
    [SerializeField] Image image;
    [SerializeField] GameObject guide;
    [SerializeField] Image guideImage;
    [SerializeField] Text[] texts;
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
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (ID > 0)
        {
            ViewGuide();
        }
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        CloseGuide();
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (ID > 0)
        {
            NewInventoryManager.Instance.OpenCraftGuide(ID);
            TargetMark.Instance.TargetSet(gameObject.GetComponent<RectTransform>());
        }
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
