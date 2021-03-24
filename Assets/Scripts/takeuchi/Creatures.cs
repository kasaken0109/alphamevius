using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{
    /// <summary> 体力最大値 </summary>
    [SerializeField] protected int maxHP = 100;
    /// <summary> 現在の体力 </summary>
    public int CurrentHP { get; protected set; }
    /// <summary> 出現位置 </summary>
    [SerializeField] protected Transform spawnPoint;
    /// <summary> 描画される当たり判定を持った画像 </summary>
    [SerializeField] protected GameObject creature;
    /// <summary> 落とすアイテム </summary>
    [SerializeField] protected ItemEnum[] haveItems;
    /// <summary> 行動可能かのフラグ </summary>
    protected bool action;
    [SerializeField] protected ActionRange actionRange;
    protected Rigidbody2D rB = null;
    /// <summary> 移動速度 </summary>
    [SerializeField] private float moveSpeed = 1.0f;
    /// <summary> X座標移動力 </summary>
    protected float moveX;
    /// <summary> Y座標移動力 </summary>
    protected float moveY;
    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        actionRange.SetOwner(this);
    }
    /// <summary>
    /// スポーン時の初期化
    /// </summary>
    public virtual void StartSpawn()
    {
        transform.position = spawnPoint.position;
        CurrentHP = maxHP;
        creature.SetActive(true);
        ActionStart();
    }
    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    public virtual void Damage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Dead();
        }
    }
    /// <summary>
    /// 死亡時の処理
    /// </summary>
    protected virtual void Dead()
    {
        ActionStop();
        FieldItemManager.Instance.DropMaterial(haveItems, transform.position);
        //foreach (var item in haveItems)
        //{
        //    FieldItemManager.Instance.DropItem(item, transform.position);
        //}
        creature.SetActive(false);
    }
    /// <summary>
    /// Creatureを行動不能にする
    /// </summary>
    public virtual void ActionStop() { action = false; }
    /// <summary>
    /// Creatureを行動可能にする
    /// </summary>
    public virtual void ActionStart() { action = true; }
    protected virtual void NormalAction()
    {
        if (actionRange.OnActionRange)
        {
            rB.velocity = new Vector2(moveX, moveY);
            moveX = 0;
            moveY = 0;
        }
        else
        {

        }
    }
}
