using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBaseMain : MonoBehaviour
{
    [SerializeField] protected ItemEnum itemType;
    public ItemBaseMain(ItemEnum type)
    {
        itemType = type;
    }
     public ItemEnum GetItemType()
    {
        return this.itemType;
    }
    public virtual bool CheckHaveOne() { return false; }
}
