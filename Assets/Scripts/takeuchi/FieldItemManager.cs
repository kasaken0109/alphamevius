using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldItemManager : MonoBehaviour
{
    public static FieldItemManager Instance { get; private set; }
    /// <summary> 同時に表示されるアイテムの最大数 </summary>
    [SerializeField] int allFieldItemsNumber = 20;
    /// <summary> フィールド上のアイテムプレハブ </summary>
    [SerializeField] GameObject itemPrefab;//コライダーとリジットボディ、FieldItemコンポーネントを設定されたプレハブ
    /// <summary> フィールド上の全アイテムの入れ物 </summary>
    List<FieldItem> fieldItems;
    /// <summary> アイテム設定用変数 </summary>
    ItemBaseMain item;
    private void Awake()
    {
        Instance = this;
        fieldItems = new List<FieldItem>();
        for (int i = 0; i < allFieldItemsNumber; i++)
        {
            GameObject item = Instantiate<GameObject>(itemPrefab);
            item.transform.SetParent(transform);
            FieldItem fieldItem = item.GetComponent<FieldItem>();
            fieldItems.Add(fieldItem);
        }
    }

    /// <summary>
    /// 指定したアイテムを指定した場所にドロップさせる関数、最大表示数を超えると古いものを消して表示させる
    /// </summary>
    /// <param name="itemType">指定アイテムの種類</param>
    /// <param name="pos">ドロップ場所</param>
    public void DropItem(ItemEnum itemType, Vector3 pos)
    {
        this.item = new ItemBaseMain(itemType);
        foreach (var item in fieldItems)
        {
            if (item.IsActive())
            {
                continue;
            }
            item.DropItem(this.item, pos);
            return;
        }
        fieldItems.OrderBy(i => i.ExistTimer).FirstOrDefault().DropItem(this.item, pos);
    }
   
    /// <summary>
    /// アイテムが飛び散るようにドロップする関数
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="pos"></param>
    public void DropMaterial(ItemEnum[] itemType,Vector3 pos)
    {
        int angleNumber = itemType.Length;
        float allAngle = 90f / angleNumber;
        float span = -45f + allAngle / 2;
        for (int i = 0; i < itemType.Length; i++)
        {
            DropItem(itemType[i], pos, GetDirection(span));
            span += allAngle;
        }

    }
    public void DropItem(ItemEnum itemType, Vector3 pos, Vector3 dir)
    {
        this.item = new ItemBaseMain(itemType);
        foreach (var item in fieldItems)
        {
            if (item.IsActive())
            {
                continue;
            }
            item.DropItem(this.item, pos, dir);
            return;
        }
        fieldItems.OrderBy(i => i.ExistTimer).FirstOrDefault().DropItem(this.item, pos, dir);
    }
    Vector3 GetDirection(float angle)
    {
        return new Vector3
        (
            Mathf.Sin(angle * Mathf.Deg2Rad),
            Mathf.Cos(angle * Mathf.Deg2Rad),
            0.0f
        ).normalized;
    }
}
