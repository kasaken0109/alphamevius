using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : ItemBaseMain
{
    public enum HealEnum
    {
        /// <summary>喉の渇きの回復</summary>
        Thirst,
        /// <summary>空腹の回復</summary>
        Hunger,
        /// <summary>怪我の回復</summary>
        Damage
    }
    public HealEnum m_healType;
    public int m_healPercentage;
    public UseItem(ItemEnum type) : base(type)
    {
        itemType = type;
        if (type == ItemEnum.Chicken)
        {
            m_healPercentage = 10;
            m_healType = HealEnum.Hunger;
        }
        else if (type == ItemEnum.Venison)
        {
            m_healPercentage = 20;
            m_healType = HealEnum.Hunger;
        }
        else if (type == ItemEnum.BakedChicken)
        {
            m_healPercentage = 25;
            m_healType = HealEnum.Hunger;
        }
        else if (type == ItemEnum.Jibie)
        {
            m_healPercentage = 40;
            m_healType = HealEnum.Hunger;
        }
        else if (type == ItemEnum.WaterBottle)
        {
            m_healPercentage = 50;
            m_healType = HealEnum.Thirst;
        }
        else if (type == ItemEnum.Herbs)
        {
            m_healPercentage = 10;
            m_healType = HealEnum.Damage;
        }
        else if (type == ItemEnum.HealingDrug)
        {
            m_healPercentage = 30;
            m_healType = HealEnum.Damage;
        }
    }
}
