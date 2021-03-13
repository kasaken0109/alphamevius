using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveOne : ItemBaseMain
{
    public HaveOne(ItemEnum type) : base(type)
    {
        itemType = type;
    }

    public override bool CheckHaveOne() { return true; }
}
