using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveOne : ItemBaseMain
{
    public int m_attackPoint;
    public int m_durableValue = 10;
    public HaveOne(ItemEnum type) : base(type)
    {
        itemType = type;
        if (type == ItemEnum.AluminiumKnife)
        {
            m_attackPoint = 1;
            m_durableValue = 3;
        }
        else if (type == ItemEnum.FragileKnife)
        {
            m_attackPoint = 3;
            m_durableValue = 3;
        }
        else if (type == ItemEnum.SmallKnife)
        {
            m_attackPoint = 5;
            m_durableValue = 10;
        }
        else if (type == ItemEnum.Machete)
        {
            m_attackPoint = 10;
            m_durableValue = 20;
        }
        else if (type == ItemEnum.Pickaxe1)
        {

        }
        else if (type == ItemEnum.Pickaxe2)
        {

        }
        else if (type == ItemEnum.Axe)
        {

        }
        else if (type == ItemEnum.Hammer)
        {

        }
    }

    public override bool CheckHaveOne() { return true; }
}
