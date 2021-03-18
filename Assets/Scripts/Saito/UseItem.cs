using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : ItemBaseMain
{
    public UseItem(ItemEnum type) : base(type)
    {
        itemType = type;
    }
}
