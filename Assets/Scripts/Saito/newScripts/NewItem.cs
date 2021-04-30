using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MaterialType
{
    None,
    Cloth,
    Plastic,
    Aluminium,
    Glass,
    Wood,
    Stone,
    Metal,
    Feathers,
    Bone,
    Fur,
    Copper,
    Herbs,
    Yarn,
    Cement,
    Charcoal,
    Gunpowder,
    RagCloth,
    Bottle,
    vinyl,
    Can,
    GqFeathers,
    GqFur,
    GqYarn,
    Gold,
    Crystal,
    Titanium,
    MeatBird,
    MeatDeer,
    BigMeat,
    MeatSpider
}
public enum ToolType
{
    None,
    Knife,
    Bow,
    Axe,
    Hammer,
    Machete,
    Pickaxe,
    Clothes,
    Trap,
    HealingHP,
    Torch,
    HealingWater,
    Bridge,
    Cooking,
    Bonfire
}

public class NewItem : ScriptableObject
{
    [SerializeField] string m_name;
    [SerializeField] Sprite m_sprite;
    [SerializeField] MaterialType[] m_needMaterials;
    [SerializeField] MaterialType[] m_getMaterials;
    [SerializeField] int ID;
    [SerializeField] int haveNumber = 0;
    [SerializeField] bool toolCheck = false;
    [SerializeField] string guideText;
    public string GetName()
    {
        return m_name;
    }
    public Sprite GetSprite()
    {
        return m_sprite;
    }
    public virtual Sprite GetFieldSprite()
    {
        return m_sprite;
    }
    public MaterialType[] GetNeedMaterials()
    {
        return m_needMaterials;
    }
    public MaterialType[] GetRecycleMaterials()
    {
        return m_getMaterials;
    }
    public int GetID()
    {
        return ID;
    }
    public int GetHaveNumber() { return haveNumber; }
    public void AddHaveNumber(int getNumber)
    {
        haveNumber += getNumber;
    }
    public void SubHaveNumber(int number)
    {
        haveNumber -= number;
        if (haveNumber < 0)
        {
            Debug.Log("所持数より多く消費した");
            haveNumber = 0;
        }
    }
    public void Zero()
    {
        haveNumber = 0;
    }
    public virtual ToolType GetToolType()
    {
        return ToolType.None;
    }
    public bool GetToolCheck()
    {
        return toolCheck;
    }
    public string GetGuideText()
    {
        return guideText;
    }
    public virtual MaterialType GetMaterialType()
    {
        return MaterialType.None;
    }
    public virtual int GetAttackPoint() { return 0; }
    public virtual int GetEfficiency() { return 0; }
    public virtual int GetCraftLevel() { return 0; }
}
