using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public static NewInventoryManager Instance { get; private set; }
    [SerializeField] NewCraftListPage[] m_craftPage;
    [SerializeField] NewPageController m_allCraftPage;
    [SerializeField] NewItemListPage[] m_itemPage;
    [SerializeField] NewPageController m_inventoryPage;
    [SerializeField] NewRecycleListPage[] m_recyclePage;
    [SerializeField] NewPageController m_allRecyclPage;
    [SerializeField] NewPageController m_cookingPage;
    [SerializeField] NewInventoryGuide m_inventoryGuide;
    [SerializeField] NewCraftGuide m_craftGuide;
    [SerializeField] NewCraftGuide m_cookingGuide;
    [SerializeField] NewRecycleGuide m_recycleGuide;
    public bool m_open = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //m_inventoryGuide.OpenGuide();
        ItemListUpdate();
        CraftSet();
        RecycleListUpdate();
    }

    public void ItemListUpdate()
    {
        List<int> itemList = NewItemManager.Instance.GetHaveItemID();
        for (int i = 0; i < itemList.Count; i++)
        {
            if (i < 15)
            {
                m_itemPage[0].UpdatePage(i, itemList[i]);
            }
            else if (i < 30)
            {
                m_itemPage[1].UpdatePage(i - 15, itemList[i]);
            }
            else if (i < 45)
            {
                m_itemPage[2].UpdatePage(i - 30, itemList[i]);
            }
            else if (i < 60)
            {
                m_itemPage[3].UpdatePage(i - 45, itemList[i]);
            }
            else if (i < 75)
            {
                m_itemPage[4].UpdatePage(i - 60, itemList[i]);
            }
            else if (i < 90)
            {
                m_itemPage[5].UpdatePage(i - 75, itemList[i]);
            }
        }
    }
    public void ItemListUpdate(int getID)
    {
        RecycleListUpdate();
        List<int> itemList = NewItemManager.Instance.GetHaveItemID();
        NewInventoryItem page = null;
        if (itemList.Count < 15)
        {
            page = m_itemPage[0].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
            if (page)
            {
                page.ChangeImage(getID);
                return;
            }
            else
            {
                page = m_itemPage[0].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault(); 
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
        else if (itemList.Count < 30)
        {
            for (int a = 0; a < 2; a++)
            {
                page = m_itemPage[a].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
            for (int k = 0; k < 2; k++)
            {
                page = m_itemPage[k].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
        else if (itemList.Count < 45)
        {
            for (int a = 0; a < 3; a++)
            {
                page = m_itemPage[a].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
            for (int k = 0; k < 3; k++)
            {
                page = m_itemPage[k].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
        else if (itemList.Count < 60)
        {
            for (int a = 0; a < 4; a++)
            {
                page = m_itemPage[a].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
            for (int k = 0; k < 4; k++)
            {
                page = m_itemPage[k].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
        else if (itemList.Count < 75)
        {
            for (int a = 0; a < 5; a++)
            {
                page = m_itemPage[a].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
            for (int k = 0; k < 5; k++)
            {
                page = m_itemPage[k].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
        else if (itemList.Count < 90)
        {
            for (int a = 0; a < 6; a++)
            {
                page = m_itemPage[a].GetItemList().ToList().Where(i => i.GetID() == getID).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
            for (int k = 0; k < 6; k++)
            {
                page = m_itemPage[k].GetItemList().ToList().Where(i => i.GetID() == 0).FirstOrDefault();
                if (page)
                {
                    page.ChangeImage(getID);
                    return;
                }
            }
        }
    }
    public void CraftSet()
    {
        List<int> itemList = NewItemManager.Instance.GetAllToolItemID();
        int[] page = new int[7];
        foreach (var item in itemList)
        {
            switch (NewItemManager.Instance.GetToolType(item))
            {
                case ToolType.None:
                    break;
                case ToolType.Knife:
                    m_craftPage[0].UpdatePage(page[0], item);
                    page[0]++;
                    break;
                case ToolType.Bow:
                    m_craftPage[0].UpdatePage(page[0], item);
                    page[0]++;
                    break;
                case ToolType.Axe:
                    m_craftPage[3].UpdatePage(page[3], item);
                    page[3]++;
                    break;
                case ToolType.Hammer:
                    m_craftPage[3].UpdatePage(page[3], item);
                    page[3]++;
                    break;
                case ToolType.Machete:
                    m_craftPage[3].UpdatePage(page[3], item);
                    page[3]++;
                    break;
                case ToolType.Pickaxe:
                    m_craftPage[3].UpdatePage(page[3], item);
                    page[3]++;
                    break;
                case ToolType.Clothes:
                    m_craftPage[1].UpdatePage(page[1], item);
                    page[1]++;
                    break;
                case ToolType.Trap:
                    m_craftPage[2].UpdatePage(page[2], item);
                    page[2]++;
                    break;
                case ToolType.HealingHP:
                    m_craftPage[4].UpdatePage(page[4], item);
                    page[4]++;
                    break;
                case ToolType.Torch:
                    m_craftPage[5].UpdatePage(page[5], item);
                    page[5]++;
                    break;
                case ToolType.HealingWater:
                    m_craftPage[4].UpdatePage(page[4], item);
                    page[4]++;
                    break;
                case ToolType.Bridge:
                    m_craftPage[4].UpdatePage(page[4], item);
                    page[4]++;
                    break;
                case ToolType.Cooking:
                    break;
                case ToolType.Bonfire:
                    m_craftPage[5].UpdatePage(page[5], item);
                    page[5]++;
                    break;
                case ToolType.Material:
                    m_craftPage[6].UpdatePage(page[6], item);
                    page[6]++;
                    break;
                default:
                    break;
            }
        }
    }
    public void RecycleListUpdate()
    {
        List<int> RecycleList = NewItemManager.Instance.GetHaveItemID();
        List<int> itemList = RecycleList.Where(r => NewItemManager.Instance.GetRecycleMaterialItems(r).Length > 0).ToList();
        for (int a = 0; a < 15; a++)
        {
            m_recyclePage[0].UpdatePage(a, 0);
            m_recyclePage[1].UpdatePage(a, 0);
            m_recyclePage[2].UpdatePage(a, 0);
        }
        for (int i = 0; i < itemList.Count; i++)
        {
            if (i < 15)
            {
                m_recyclePage[0].UpdatePage(i, itemList[i]);
            }
            else if (i < 30)
            {
                m_recyclePage[1].UpdatePage(i - 15, itemList[i]);
            }
            else if (i < 45)
            {
                m_recyclePage[2].UpdatePage(i - 30, itemList[i]);
            }
        }
    }
    public void OpenItemGuide(int ID)
    {
        m_inventoryGuide.OpenGuide(ID);
    }
    public void OpenCraftGuide(int ID)
    {
        m_craftGuide.OpenGuide(ID);
    }
    public void OpenRecycleGuide(int ID)
    {
        m_recycleGuide.OpenGuide(ID);
    }
    public void OpenCookingGuide(int ID)
    {
        m_cookingGuide.OpenGuide(ID);
    }
    public void OnClickClose()
    {
        m_open = false;
        MapManager.Instance.CloseMap();
        m_inventoryPage.ClosePage();
        m_allCraftPage.ClosePage();
        m_allRecyclPage.ClosePage();
        m_inventoryGuide.CloseGuide();
        m_craftGuide.CloseGuide();
        m_cookingGuide.CloseGuide();
        m_recycleGuide.CloseGuide();
        m_cookingPage.ClosePage();
        NewCraftManager.Instance.SetTargetID(0);
    }

    public void OnClickOpenInventory()
    {
        if (m_open)
        {
            OnClickClose();
            return;
        }
        OnClickClose();
        m_open = true;
        int a = 0;
        List<int> itemList = NewItemManager.Instance.GetHaveItemID();
        int b = itemList.Count;
        if (b <= 15)
        {
            a = 0;
        }
        else if (b <= 30)
        {
            a = 1;
        }
        else if (b <= 45)
        {
            a = 2;
        }
        else if (b <= 60)
        {
            a = 3;
        }
        else if (b <= 75)
        {
            a = 4;
        }
        else if (b <= 90)
        {
            a = 5;
        }
        m_inventoryPage.OpenPage(a);
    }
    public void OnClickOpenCraft(int page)
    {
        OnClickClose();
        m_open = true;
        m_allCraftPage.OpenChoicePage(page);
    }
    public void OnClickOpenRecycle()
    {
        OnClickClose();
        m_open = true;
        List<int> RecycleList = NewItemManager.Instance.GetHaveItemID();
        List<int> itemList = RecycleList.Where(r => NewItemManager.Instance.GetRecycleMaterialItems(r).Length > 0).ToList();
        int i = 0;
        if (itemList.Count < 15)
        {
            i = 0;
        }
        else if (itemList.Count < 30)
        {
            i = 1;
        }
        else if (itemList.Count < 45)
        {
            i = 2;
        }
        m_allRecyclPage.OpenPage(i);
    }
    public void OnClickOpenCooking()
    {
        m_open = true;
        m_cookingPage.OpenPage(0);
    }
}
