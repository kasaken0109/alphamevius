using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveItemManager : MonoBehaviour
{
    public static HaveItemManager Instance { get; private set; }
    /// <summary>
    /// ０：アルミナイフ、
    /// </summary>
    [SerializeField] HaveItem[] items;
    List<int> itemsCurrentHP;
    private void Awake()
    {
        Instance = this;
        itemsCurrentHP = new List<int>();
        foreach (var item in items)
        {
            itemsCurrentHP.Add(item.GetMaxHP());
        }
    }
    public int GetItemMaxHP(int ID) { return items[ID].GetMaxHP(); }
    public int GetItemCurrentHP(int ID) { return itemsCurrentHP[ID]; }
    public void UseItem(int ID) { itemsCurrentHP[ID]--; }
}
