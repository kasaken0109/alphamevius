using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialitem : ItemBaseMain
{
    public Materialitem(ItemEnum type) : base(type)
    {
        itemType = type;
    }
    public override bool CheckHaveOne() { return false; }
}
