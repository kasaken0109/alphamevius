using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class NewItemManager : MonoBehaviour
{
    ToolType m_equipmentItem = ToolType.None;
    int[] m_hotbarID = new int[10];
    [SerializeField] NewItemLibrary m_library = null;
    List<NewItem> m_itemLiblary = new List<NewItem>();
    private void Awake()
    {
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
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(GetName(8));
            AddItem(8, 10);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(HaveItemNumber(8));
        }
    }
    public ToolType GetEquipmentItem()
    {
        return m_equipmentItem;
    }
    public void SetEquipmentItem(ToolType toolType)
    {
        m_equipmentItem = toolType;
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
    public void AddItem(int ID,int number)
    {
        m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().AddHaveNumber(number);
    }
    public void SubItem(int ID, int number)
    {
        m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().SubHaveNumber(number);
    }
    public int HaveItemNumber(int ID)
    {
        return m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetHaveNumber();
    }
    private void Allzero()
    {
        m_itemLiblary.ForEach(i => i.Zero());
    }
}
