﻿using System.Collections;
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
    Cooking
}

public class NewItem : ScriptableObject
{
    [SerializeField] string m_name;
    [SerializeField] Sprite m_sprite;
    [SerializeField] MaterialType[] m_needMaterials;
    [SerializeField] MaterialType[] m_getMaterials;
    [SerializeField] int ID;
    [SerializeField] int haveNumber = 0;
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
    public int GetHaveNumber() { return haveNumber; }
    public void AddHaveNumber(int getNumber)
    {
        haveNumber += getNumber;
    }
    public void SubHaveNumber(int number)
    {
        haveNumber -= number;
    }
    public void Zero()
    {
        haveNumber = 0;
    }
    public virtual ToolType GetToolType()
    {
        return ToolType.None;
    }

}
