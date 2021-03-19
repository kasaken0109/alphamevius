using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    /// <summary> アイテムの種類 </summary>
    [SerializeField] ItemBaseMain item;
    /// <summary> 入手フラグ </summary>
    bool getFlag = false;
    float toExistTime = 8f;
    float existTimer = 0f;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        existTimer -= Time.deltaTime;
        if (existTimer <= 0)
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
        existTimer = toExistTime;
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!getFlag)
            {
                getFlag = true;
                ItemManage.Instance.GetItem(item);
                this.gameObject.SetActive(false);
            }
        }
    }
}
