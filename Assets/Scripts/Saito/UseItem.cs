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
    public override void UseHeal()
    {
        switch (m_healType)
        {
            case UseType.Thirst:
                PlayerManager.Instance.HealingHydrate(m_healPercentage);
                break;
            case UseType.Hunger:
                PlayerManager.Instance.HealingHunger(m_healPercentage);
                break;
            case UseType.Damage:
                PlayerManager.Instance.HealingHP(m_healPercentage);
                break;
            default:
                break;
        }
    }
    public override void UseTrap()
    {

    }
    public UseType GetHealType() { return m_healType; }
    public int GetHealPercentage() { return m_healPercentage; }
}