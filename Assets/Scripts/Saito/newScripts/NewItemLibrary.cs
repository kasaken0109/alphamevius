using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "ItemLibrary" , menuName = "Library")]
public class NewItemLibrary : ScriptableObject
{
    private void Awake()
    {
        return;
        foreach (var item in m_materialItemData)
        {
            m_itemLiblary.Add(item);
        }
        foreach (var item in m_toolItemData)
        {
            m_itemLiblary.Add(item);
        }
        m_itemLiblary.OrderBy(item => item.GetID());
    }
    [SerializeField] NewMaterialItem[] m_materialItemData;
    [SerializeField] NewToolItem[] m_toolItemData;
    List<NewItem> m_itemLiblary = new List<NewItem>();
    public NewToolItem GetToolItem()
    {
        return m_toolItemData[0];
    }
    public NewMaterialItem GetMaterialItem()
    {
        return m_materialItemData[0];
    }
    public int GetAllItemsNumber()
    {
        return m_materialItemData.Length + m_toolItemData.Length;
    }
    public Sprite GetSpriteLiblary(int ID)
    {
        return m_itemLiblary[ID].GetSprite();
    }
        public Sprite GetSprite(int ID)
    {
        if (ID < m_materialItemData.Length)
        {
            return m_materialItemData[ID].GetSprite();
        }
        else if (ID < m_materialItemData.Length + m_toolItemData.Length)
        {
            return m_toolItemData[ID - m_materialItemData.Length].GetSprite();
        }
        else
        {
            return null;
        }
    }
}
