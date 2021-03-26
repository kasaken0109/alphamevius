using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveItem : ItemBaseMain
{
    public HaveItem(ItemEnum type) : base(type)
    {
        itemType = type;
    }
    [SerializeField] int maxHP;
    [SerializeField] int attackPoint;
    [SerializeField] int ID;
    public int GetMaxHP()
    {
        return maxHP;
    }
    public int GetAttack()
    {
        return attackPoint;
    }
    public int GetID()
    {
        return ID;
    }

}
