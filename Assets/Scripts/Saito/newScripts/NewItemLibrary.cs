using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "ItemLibrary" , menuName = "Library")]
public class NewItemLibrary : ScriptableObject
{
    
    [SerializeField] NewMaterialItem[] m_materialItemData;
    [SerializeField] NewToolItem[] m_toolItemData;
    //List<NewItem> m_itemLiblary = new List<NewItem>();
    public NewToolItem[] GetToolItem()
    {
        return m_toolItemData;
    }
    public NewMaterialItem[] GetMaterialItem()
    {
        return m_materialItemData;
    }
    public int GetAllItemsNumber()
    {
        return m_materialItemData.Length + m_toolItemData.Length;
    }
    //public Sprite GetSpriteLiblary(int ID)
    //{
    //    return m_itemLiblary[ID].GetSprite();
    //}
    //public Sprite GetSprite(int ID)
    //{
    //    Sprite sprite;
    //    sprite = m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetSprite();
    //    return sprite;
    //}
    //public string GetName(int ID)
    //{
    //    string name;
    //    name = m_itemLiblary.Where(i => i.GetID() == ID).FirstOrDefault().GetName();
    //    return name;
    //}
    //public void AllItemName()
    //{
    //    foreach (var item in m_itemLiblary)
    //    {
    //        Debug.Log(item.GetName());
    //    }
    //}
}
