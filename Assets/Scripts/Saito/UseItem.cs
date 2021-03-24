using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : ItemBaseMain
{
    public enum UseType
    {
        /// <summary>喉の渇きの回復</summary>
        Thirst,
        /// <summary>空腹の回復</summary>
        Hunger,
        /// <summary>怪我の回復</summary>
        Damage,
        /// <summary>罠</summary>
        Trap
    }
    public UseType m_healType;
    public int m_healPercentage;
    public UseItem(ItemEnum type) : base(type)
    {
        itemType = type;
    }
    public UseType GetHealType() { return m_healType; }
    public int GetHealPercentage() { return m_healPercentage; }
}