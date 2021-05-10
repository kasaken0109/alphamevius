using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
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
    bool m_isCraft = false;
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
            image.color = new Color(0.6f, 0.6f, 0.6f);
            ViewGuide();
        }
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (IsCraftCheck())
        {
            ChangeNormalColor();
        }
        else
        {
            ChangeCantCraftColor();
        }
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
    public void ChangeCantCraftColor()
    {
        image.color = new Color(0.2f, 0.2f, 0.2f);
    }
    public void ChangeNormalColor()
    {
        image.color = new Color(1, 1, 1);
    }
    public void ViewGuide()
    {
        guide.SetActive(true);
    }
    public void CloseGuide()
    {
        guide.SetActive(false);
    }
    public bool IsCraftCheck()
    {
        MaterialType[] needMaterials = NewItemManager.Instance.GetNeedMaterialItems(ID); ;
        int[] idList = new int[6];
        int[] needMaterialNumbers = new int[6];
        var result = needMaterials.ToList().Distinct();
        int index = 0;
        foreach (var item in result)
        {
            idList[index] = NewItemManager.Instance.GetMaterialId(item);
            needMaterialNumbers[index] = needMaterials.ToList().Count(k => item == k);
            index++;
        }
        for (int j = 0; j < idList.Length; j++)
        {
            if (NewItemManager.Instance.HaveItemNumber(idList[j]) < needMaterialNumbers[j])
            {
                return false;
            }
        }
        return true;
    } 
}
