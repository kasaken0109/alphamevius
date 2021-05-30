using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    /// <summary> アイテムの入れ物 </summary>
    ItemBaseMain item;
    MaterialType materialType = MaterialType.None;
    /// <summary> 入手フラグ </summary>
    bool getFlag = false;
    /// <summary> 存在する時間 </summary>
    float toExistTime = 80f;
    /// <summary> 存在時間のタイマー </summary>
    public float ExistTimer { get; private set; } = 0f;
    [SerializeField]SpriteRenderer itemImage;
    Transform player;
    private bool drop;
    private void Start()
    {
        player = Player.Instance.transform;
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!drop)
        {
            return;
        }
        ExistTimer -= Time.deltaTime;
        if (ExistTimer <= 0)
        {
            this.gameObject.SetActive(false);
            drop = false;
        }
        if (startMoveTimer > 0)
        {
            startMoveTimer -= Time.deltaTime;
            transform.position += moveDir * moveSpeed * 2 * Time.deltaTime;
            xxx = true;
        }
        else if (xxx)
        {
            transform.position -= new Vector3(0, moveSpeed * 2 * Time.deltaTime);
            if (transform.position.y <= earthPosY)
            {
                xxx = false;
                getFlag = false;
                yyy = true;
            }
        }
        else if (yyy)
        {
            transform.position += 10 * (player.position - transform.position).normalized * Time.deltaTime;
        }
    }
    /// <summary>
    /// アイテムを落とす為の関数
    /// </summary>
    /// <param name="item">アイテムの種類</param>
    /// <param name="pos">落とす場所</param>
    public void DropItem(ItemBaseMain item, Vector3 pos)
    {
        this.item = item;
        transform.position = pos;
        getFlag = false;
        ExistTimer = toExistTime;
        this.gameObject.SetActive(true);
    }
    public void DropItem(MaterialType type, Vector3 pos)
    {
        materialType = type;
        transform.position = pos;
        getFlag = false;
        ExistTimer = toExistTime;
        this.gameObject.SetActive(true);
    }
    private float moveTime = 0.5f;
    private float startMoveTimer;
    [SerializeField]
    private float moveSpeed = 10.0f;
    Vector3 moveDir = Vector3.zero;
    private bool xxx;
    private float earthPosY;
    private bool yyy;
    public void DropItem(MaterialType type, Vector3 pos, Vector3 moveDir)
    {
        //Debug.Log("呼ばれた");
        materialType = type;
        itemImage.sprite = NewItemManager.Instance.GetItem(NewItemManager.Instance.GetMaterialId(type)).GetFieldSprite();
        transform.position = pos;
        this.moveDir = moveDir;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, moveDir);
        startMoveTimer = moveTime;
        earthPosY = pos.y - 0.5f;
        xxx = false;
        getFlag = true;
        drop = true;
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
                if (item)
                {
                    ItemManage.Instance.SetItem(item);
                }
                if (materialType != MaterialType.None)
                {
                    SoundManager.Instance.PlayObjectSE(12);
                    NewItemManager.Instance.AddItem(NewItemManager.Instance.GetMaterialId(materialType), 1);
                }
                drop = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!getFlag)
            {
                getFlag = true;
                if (item)
                {
                    ItemManage.Instance.SetItem(item);
                }
                if (materialType != MaterialType.None)
                {
                    SoundManager.Instance.PlayObjectSE(12);
                    NewItemManager.Instance.AddItem(NewItemManager.Instance.GetMaterialId(materialType), 1);
                }
                drop = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
