using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class ZInventoryManager : MonoBehaviour
{
    public static ZInventoryManager Instance { get; private set; }
    [SerializeField] ZInventoryTools[] m_inventoryTools;
    [SerializeField] ZInventoryHaveItem[] m_haveMaterials;
    [SerializeField] RectTransform m_haveMaterialBar;
    [SerializeField] ZCraftPanelControl m_craftPanel;
    [SerializeField] ZRecyclePanelControl m_recyclePanel;
    [SerializeField] GameObject m_closeButton;
    [SerializeField] RectTransform m_cookingPanel;
    [SerializeField] ZCookingGuid m_cookingItems;
    [SerializeField] RectTransform m_helpPanel;
    [SerializeField] ZHelpPanelControl m_helps;
    [SerializeField] ZTestItmeMove[] m_itmes;
    [SerializeField] Image m_allCloseButton;
    bool start;
    public bool FullInventory { get; private set; }
    List<int> m_haveToolData;
    private void Awake()
    {
        Instance = this;
        m_haveToolData = new List<int>();
    }
    private void Start()
    {
        OnClickCloseAll();
    }
    public void SetRecycleTools(ZRecycleItem[] recycleItems)
    {
        for (int i = 0; i < recycleItems.Length; i++)
        {
            m_inventoryTools[i].SetRecycle(recycleItems[i]);
        }
    }
    public void ToolGet(int itemID)
    {
        m_haveMaterials.ToList().ForEach(i => i.DataUpdate());
        foreach (var item in m_inventoryTools)
        {
            if (item.GetItemID() == 0)
            {
                item.SetItem(itemID);
                foreach (var check in m_inventoryTools)
                {
                    if (check != item && check.GetItemID() == 0)
                    {
                        FullInventory = false;
                        return;
                    }
                }
                MessgaeManager.ViweMessage("インベントリが一杯だ");
                FullInventory = true;
                return;
            }
        }
        FullInventory = false;
    }
    public void PositionReset(int pos)
    {
        m_inventoryTools[pos].ResetItem();
        FullInventory = false;
    }
    public void RecycleTool()
    {
        m_haveMaterials.ToList().ForEach(i => i.DataUpdate());
        FullInventory = false;
    }
    public void SortInventory()
    {
        var haveTools = m_inventoryTools.Where(i => i.GetItemID() > 0).ToArray().OrderByDescending(i => i.GetItemID());
        foreach (var item in haveTools)
        {
            m_haveToolData.Add(item.GetItemID());
        }
        InventoryAllReset();
        for (int i = 0; i < m_haveToolData.Count; i++)
        {
            m_inventoryTools[i].SetItem(m_haveToolData[i]);
        }
        m_haveToolData.Clear();
    }
    void InventoryAllReset()
    {
        m_inventoryTools.ToList().ForEach(i => i.ResetItem());
    }
    public void ViewNeedMaterial(int material,int number)
    {
        var target = m_haveMaterials.Where(s => s.GetItemID() == material).FirstOrDefault();
        if (target)
        {
            target.CraftCheck(number);
        }
    }
    public void ViewNeedMaterial(int[] material, int[] number)
    {
        if (material.Length != number.Length)
        {
            Debug.Log("入力が不正");
        }
        ZInventoryHaveItem target;
        for (int i = 0; i < material.Length; i++)
        {
            int a = material[i];
            target = m_haveMaterials.Where(s => s.GetItemID() == a).FirstOrDefault();
            if (target)
            {
                target.CraftCheck(number[i]);
            }
        }
    }
    public void ViewGetMaterial(int material, int number)
    {
        var target = m_haveMaterials.Where(s => s.GetItemID() == material).FirstOrDefault();
        if (target)
        {
            target.RecycleCheck(number);
        }
    }
    public void ViewGetMaterial(int[] material, int[] number)
    {
        if (material.Length != number.Length)
        {
            Debug.Log("入力が不正");
        }
        ZInventoryHaveItem target;
        for (int i = 0; i < material.Length; i++)
        {
            int a = material[i];
            target = m_haveMaterials.Where(s => s.GetItemID() == a).FirstOrDefault();
            if (target)
            {
                target.RecycleCheck(number[i]);
            }
        }
    }
    public void ViewMaterialReset()
    {
        m_craftPanel.PageUpdate();
        m_cookingItems.PageUpdate();
        m_haveMaterials.ToList().ForEach(i => i.ClearText());
    }
    public void OnClickOpenCraft()
    {
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        PickMarkReset();
        ViewMaterialReset();
        m_craftPanel.OnClickOpenCraft();
        m_recyclePanel.CloseRecycle();
        m_haveMaterialBar.localPosition = new Vector2(0, 0);
        m_closeButton.SetActive(true);
        NewCraftManager.Instance.SetTargetID(0);
        SoundManager.Instance.PlayUISound();
    }
    public void OnClickOpenRecycle()
    {
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        PickMarkReset();
        ViewMaterialReset();
        m_recyclePanel.OnClickOpenRecycle();
        m_craftPanel.CloseCraft();
        m_haveMaterialBar.localPosition = new Vector2(0, 0);
        m_closeButton.SetActive(true);
        NewCraftManager.Instance.SetTargetID(0);
        SoundManager.Instance.PlayUISound();
    }
    public void OnClickOpenCooking()
    {
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        PickMarkReset();
        ViewMaterialReset();
        m_craftPanel.CloseCraft();
        m_recyclePanel.CloseRecycle();
        m_haveMaterialBar.localPosition = new Vector2(0, 0);
        m_cookingPanel.localPosition = new Vector2(0, 0);
        m_closeButton.SetActive(true);
        NewCraftManager.Instance.SetTargetID(0);
        SoundManager.Instance.PlayUISound();
    }
    public void OnClickOpenHelp()
    {
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        m_helpPanel.localPosition = new Vector2(0, 0);
        m_closeButton.SetActive(true);
        SoundManager.Instance.PlayUISound();
    }
    public void OnClickOpenMap()
    {
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        MapManager.Instance.ActiveMap();
        m_closeButton.SetActive(true);
        SoundManager.Instance.PlayUISound();
        m_allCloseButton.color = new Color(0, 0, 0, 0);
    }
    public void OnClickCloseAll()
    {
        MapManager.Instance.CloseMap();
        PickMarkReset();
        m_helps.AllClose();
        m_craftPanel.CloseCraft();
        m_recyclePanel.CloseRecycle();
        m_closeButton.SetActive(false);
        m_haveMaterialBar.localPosition = new Vector2(2000, 2000);
        m_cookingPanel.localPosition = new Vector2(2000, 2000);
        m_helpPanel.localPosition = new Vector2(2000, 2000);
        NewCraftManager.Instance.SetTargetID(0);
        m_allCloseButton.color = new Color(0, 0, 0, 0.6f);
        if (PlayerManager.Instance.CurrentHP <= 0 || PlayerManager.Instance.Win)
        {
            return;
        }
        if (!start)
        {
            start = true;
            return;
        }
        SoundManager.Instance.PlayUISound();
    }
    public void EquipmentReset()
    {
        m_inventoryTools.ToList().ForEach(i => i.EquipmentOut());
    }
    public void EquipmentSet(ZInventoryTools inventoryTool)
    {
        m_inventoryTools.ToList().ForEach(i => i.EquipmentOut());
        inventoryTool.EquipmentSet();
    }
    public void ItemUpdate()
    {
        m_haveMaterials.ToList().ForEach(i => i.DataUpdate());
    }
    public void PickMarkReset()
    {
        m_recyclePanel.PickResetAll();
    }
    public void Cooking()
    {
        m_cookingItems.Cooking();
    }
    public void ItemGet(int s1,Vector2 p1)
    {
        var target = m_haveMaterials.Where(s => s.GetItemID() == s1).FirstOrDefault();
        if (target)
        {
            m_itmes[0].ItemGetMove(target.GetSprite(), p1, target.GetComponent<RectTransform>().position);
        }
    }
    public void ItemGet(int s1, Vector2 p1, int s2, Vector2 p2)
    {
        var target = m_haveMaterials.Where(s => s.GetItemID() == s1).FirstOrDefault();
        if (target)
        {
            m_itmes[0].ItemGetMove(target.GetSprite(), p1, target.GetComponent<RectTransform>().position);
        }
        target = m_haveMaterials.Where(s => s.GetItemID() == s2).FirstOrDefault();
        if (target)
        {
            m_itmes[1].ItemGetMove(target.GetSprite(), p2, target.GetComponent<RectTransform>().position);
        }
    }
    public void ItemGet(int s1, Vector2 p1, int s2, Vector2 p2, int s3, Vector2 p3)
    {
        var target = m_haveMaterials.Where(s => s.GetItemID() == s1).FirstOrDefault();
        if (target)
        {
            m_itmes[0].ItemGetMove(target.GetSprite(), p1, target.GetComponent<RectTransform>().position);
        }
        target = m_haveMaterials.Where(s => s.GetItemID() == s2).FirstOrDefault();
        if (target)
        {
            m_itmes[1].ItemGetMove(target.GetSprite(), p2, target.GetComponent<RectTransform>().position);
        }
        target = m_haveMaterials.Where(s => s.GetItemID() == s3).FirstOrDefault();
        if (target)
        {
            m_itmes[2].ItemGetMove(target.GetSprite(), p3, target.GetComponent<RectTransform>().position);
        }
    }
}
