using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventoryManager : MonoBehaviour
{
    public static NewInventoryManager Instance { get; private set; }
    [SerializeField] NewInventoryItem[] m_craftList;
    [SerializeField] NewItemListPage m_page1;
    [SerializeField] NewItemListPage m_page2;
    [SerializeField] NewItemListPage m_page3;
    [SerializeField] NewItemListPage m_page4;
    [SerializeField] NewItemListPage m_page5;
    [SerializeField] NewItemListPage m_page6;
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
    }
    public void ItemListUpdate()
    {
        List<int> itemList = NewItemManager.Instance.GetHaveItemID();
        for (int i = 0; i < itemList.Count; i++)
        {
            if (i < 15)
            {
                m_page1.UpdatePage(i, itemList[i]);
            }
            else if (i < 30)
            {
                m_page2.UpdatePage(i - 15, itemList[i]);
            }
            else if (i < 45)
            {
                m_page3.UpdatePage(i - 30, itemList[i]);
            }
            else if (i < 60)
            {
                m_page4.UpdatePage(i - 45, itemList[i]);
            }
            else if (i < 75)
            {
                m_page5.UpdatePage(i - 60, itemList[i]);
            }
            else if (i < 90)
            {
                m_page6.UpdatePage(i - 75, itemList[i]);
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
