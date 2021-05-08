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
    /// <summary>
    /// index番号
    /// 0 : タイトル
    /// 1 : 必要素材
    /// 2 : フレーバーテキスト
    /// </summary>
    [SerializeField] Text[] texts;
    private void Start()
    {
        image.sprite = NewItemManager.Instance.GetSprite(ID);
    }
    public void ChangeImage(int ID)
    {
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
        guideImage.sprite = NewItemManager.Instance.GetSprite(ID);
        texts[0].text = NewItemManager.Instance.GetName(ID);
        texts[1].text = NewItemManager.Instance.GetItem(ID).GetNeedMaterialsText();
        texts[2].text = NewItemManager.Instance.GetItem(ID).GetGuideText();
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
