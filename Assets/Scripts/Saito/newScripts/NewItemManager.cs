using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NewItemManager : MonoBehaviour
{
    public static NewItemManager Instance { get; private set; }
    NewItemEffectManager[] m_hotbar = new NewItemEffectManager[10];
    [SerializeField] NewItemLibrary m_library = null;
    List<NewItem> m_itemLiblary = new List<NewItem>();
    private void Awake()
    {
        Instance = this;
        foreach (var item in m_library.GetMaterialItem())
        {
            m_itemLiblary.Add(item);
        }
        foreach (var item in m_library.GetToolItem())
        {
            m_itemLiblary.Add(item);
        }
        Allzero();

    }

    
    public NewItemEffectManager Hotber(int Number)
    {
        return m_hotbar[Number];
    }
    public ToolType GetToolType(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetToolType();
    }
    public NewItem GetItem(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault();
    }
    public Sprite GetSpriteLiblary(int ID)
    {
        return m_itemLiblary[ID].GetSprite();
    }
    public Sprite GetSprite(int ID)
    {
        Sprite sprite;
        sprite = m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetSprite();
        return sprite;
    }
    public string GetName(int ID)
    {
        string name;
        name = m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetName();
        return name;
    }
    public void AddItem(int ID, int number)
    {
        m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().AddHaveNumber(number);
        NewInventoryManager.Instance.ItemListUpdate(ID);
    }
    public void SubItem(int ID, int number)
    {
        m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().SubHaveNumber(number);
        NewInventoryManager.Instance.ItemListUpdate(ID);
    }
    public int HaveItemNumber(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetHaveNumber();
    }
    private void Allzero()
    {
        m_itemLiblary.ForEach(i => i.Zero());
    }
    public List<int> GetAllItemID()
    {
        List<int> IDlist = new List<int>();
        foreach (var item in m_itemLiblary)
        {
            IDlist.Add(item.GetID());
        }
        return IDlist;
    }
    public List<int> GetAllToolItemID()
    {
        List<int> IDlist = new List<int>();
        foreach (var item in m_itemLiblary)
        {
            if (item.GetToolType() != ToolType.None)
            {
                IDlist.Add(item.GetID());
            }
        }
        return IDlist;
    }
    public List<int> GetHaveItemID()
    {
        List<int> IDlist = new List<int>();
        foreach (var item in m_itemLiblary)
        {
            if (item.GetHaveNumber() > 0)
            {
                IDlist.Add(item.GetID());
            }
        }
        return IDlist;
    }
    public string GetGuideText(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetGuideText();
    }
    public bool GetToolCheck(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetToolCheck();
    }
    public MaterialType[] GetNeedMaterialItems(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetNeedMaterials();
    }
    public MaterialType[] GetRecycleMaterialItems(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetRecycleMaterials();
    }
    public int GetMaterialId(MaterialType type)
    {
        NewItem item = m_itemLiblary.Where(i => i.GetMaterialType() == type).FirstOrDefault();
        if (item)
        {
            return item.GetID();
        }
        return 0;
    }
    public void GetWaterBottle(int efficiencyNum)
    {
        NewItem item = m_itemLiblary.Where(i => i.GetToolType() == ToolType.HealingWater)
                                    .Where(i => i.GetEfficiency() == efficiencyNum).FirstOrDefault();
        AddItem(item.GetID(), 1);
        item = m_itemLiblary.Where(i => i.GetToolType() == ToolType.EmptyBottle)
                                    .Where(i => i.GetEfficiency() == efficiencyNum).FirstOrDefault();
        SubItem(item.GetID(), 1);
    }
    public void GetEmptyBottle(int efficiencyNum)
    {
        NewItem item = m_itemLiblary.Where(i => i.GetToolType() == ToolType.EmptyBottle)
                                    .Where(i => i.GetEfficiency() == efficiencyNum).FirstOrDefault();
        AddItem(item.GetID(), 1);
        item = m_itemLiblary.Where(i => i.GetToolType() == ToolType.HealingWater)
                                    .Where(i => i.GetEfficiency() == efficiencyNum).FirstOrDefault();
        SubItem(item.GetID(), 1);
    }
}
