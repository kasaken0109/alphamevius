using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HaveItemManager : MonoBehaviour
{
    public static HaveItemManager Instance { get; private set; }
    /// <summary>
    /// ID割り当て
    /// 0:アルミナイフ
    /// 1:脆いナイフ
    /// 2:小さいナイフ
    /// 3:マチェット
    /// 4:ピッケル1
    /// 5:ピッケル2
    /// 6:斧
    /// 7:ハンマー
    /// </summary>
    [SerializeField] HaveItem[] items;
    List<int> itemsCurrentHP;
    [SerializeField] Slider[] sliders;
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
    public void UseItem(int ID) 
    { 
        itemsCurrentHP[ID]--;
        sliders[ID].value = itemsCurrentHP[ID] / items[ID].GetMaxHP();
    }
}
