using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialItmes", menuName = "MaterialItems")]
public class NewMaterialItem : NewItem
{
    [SerializeField] ToolType m_toolType = ToolType.None;
    [SerializeField] MaterialType m_materialType;
    [SerializeField] Sprite m_fieldSprite;
    /// <summary>必要レベル,初期値0</summary>
    [SerializeField] int m_craftLevel = 0;
    public override Sprite GetFieldSprite()
    {
        return m_fieldSprite;
    }
    public override MaterialType GetMaterialType()
    {
        return m_materialType;
    }
    public override ToolType GetToolType()
    {
        return m_toolType;
    }
    public override int GetCraftLevel() { return m_craftLevel; }
}
