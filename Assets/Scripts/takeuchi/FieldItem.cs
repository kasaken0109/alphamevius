using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    /// <summary> アイテムの入れ物 </summary>
    ItemBaseMain item;
    /// <summary> 入手フラグ </summary>
    bool getFlag = false;
    /// <summary> 存在する時間 </summary>
    float toExistTime = 8f;
    /// <summary> 存在時間のタイマー </summary>
    public float ExistTimer { get; private set; } = 0f;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        ExistTimer -= Time.deltaTime;
        if (ExistTimer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// アイテムを落とす為の関数
    /// </summary>
    /// <param name="item">アイテムの種類</param>
    /// <param name="pos">落とす場所</param>
    public void DropItem(ItemBaseMain item,Vector3 pos)
    {
        this.item = item;
        transform.position = pos;
        getFlag = false;
        ExistTimer = toExistTime;
        this.gameObject.SetActive(true);
    }
    /// <summary>
    /// アクティブ状態かどうかを返す
    /// </summary>
    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!getFlag)
            {
                getFlag = true;
                ItemManage.Instance.SetItem(item);
                this.gameObject.SetActive(false);
            }
        }
    }
}
