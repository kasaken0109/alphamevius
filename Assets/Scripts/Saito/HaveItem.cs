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
    public int GetMaxHP()
    {
        return maxHP;
    }
    public int GetAttack()
    {
        return attackPoint;
    }
}
