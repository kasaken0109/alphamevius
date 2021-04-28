using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public static NewInventoryManager Instance { get; private set; }
    [SerializeField] NewCraftListPage[] m_craftPage;
    [SerializeField] NewPageController m_allCraftPage;
    [SerializeField] NewItemListPage[] m_itemPage;
    [SerializeField] NewPageController m_inventoryPage;
    [SerializeField] NewInventoryItem[] m_recycleList;
    [SerializeField] NewInventoryItem[] m_cookingList;
    [SerializeField] NewInventoryGuide m_inventoryGuide;
    [SerializeField] NewCraftGuide m_craftGuide;
    [SerializeField] NewCraftGuide m_cookingGuide;
    [SerializeField] NewRecycleGuide m_recycleGuide;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //m_inventoryGuide.OpenGuide();
        ItemListUpdate();
        CraftSet();
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
    public void CraftSet()
    {
        List<int> itemList = NewItemManager.Instance.GetAllToolItemID();
        int[] page = new int[7];
        foreach (var item in itemList)
        {
            Debug.Log(item);
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
                    m_craftPage[6].UpdatePage(page[6], item);
                    page[6]++;
                    break;
                default:
                    break;
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
        m_inventoryPage.ClosePage();
        m_allCraftPage.ClosePage();
        m_inventoryGuide.CloseGuide();
        m_craftGuide.CloseGuide();
        m_cookingGuide.CloseGuide();
        m_recycleGuide.CloseGuide();
    }

    public void OnClickOpenInventory()
    {
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
}
