using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialItmes", menuName = "MaterialItems")]
public class NewMaterialItem : NewItem
{
    [SerializeField] MaterialType m_materialType;
    [SerializeField] Sprite m_fieldSprite;
    public override Sprite GetFieldSprite()
    {
        return m_fieldSprite;
    }
    public override MaterialType GetMaterialType()
    {
        return m_materialType;
    }
}
