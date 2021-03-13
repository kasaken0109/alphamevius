using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventItem : ItemBaseMain
{
    public EventItem(ItemEnum type) : base(type)
    {
        itemType = type;
    }
}