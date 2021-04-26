using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialType
{

}
public enum ToolType
{
    None,

}

public class NewItem : ScriptableObject
{
    [SerializeField] string m_name;
    [SerializeField] Sprite m_sprite;
    [SerializeField] MaterialType[] m_needMaterials;
    [SerializeField] MaterialType[] m_getMaterials;
    [SerializeField] int ID;
    public string GetName()
    {
        return m_name;
    }
    public Sprite GetSprite()
    {
        return m_sprite;
    }
    public MaterialType[] GetNeedMaterials()
    {
        return m_needMaterials;
    }
    public MaterialType[] GetGetMaterials()
    {
        return m_getMaterials;
    }
    public int GetID()
    {
        return ID;
    }
}
