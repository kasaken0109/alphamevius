using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{
    private enum MoveAngle
    {
        Up,
        Left,
        Right,
        Down,
    }
    /// <summary> 体力最大値 </summary>
    [SerializeField] protected int maxHP = 100;
    /// <summary> 現在の体力 </summary>
    public int CurrentHP { get; protected set; }
    /// <summary> 出現位置 </summary>
    [SerializeField] protected Transform spawnPoint;
    /// <summary> 描画される画像 </summary>
    [SerializeField] protected GameObject creature;
    /// <summary> 落とすアイテム </summary>
    [SerializeField] protected ItemEnum[] haveItems;
    /// <summary> 行動可能かのフラグ </summary>
    protected bool action;
    [SerializeField] protected ActionRange actionRange;
    protected Rigidbody2D rB = null;
    /// <summary> 移動速度 </summary>
    [SerializeField] protected float moveSpeed = 1.0f;
    /// <summary> X座標移動力 </summary>
    protected float moveX;
    /// <summary> Y座標移動力 </summary>
    protected float moveY;
    protected Vector3 moveDir = Vector3.zero;
    protected CircleCollider2D circleCollider;
    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
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
        circleCollider.enabled = true;
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
        circleCollider.enabled = false;
    }
    /// <summary>
    /// Creatureを行動不能にする
    /// </summary>
    public virtual void ActionStop() { action = false; }
    /// <summary>
    /// Creatureを行動可能にする
    /// </summary>
    public virtual void ActionStart() { action = true; }
    private int testCount;
    private MoveAngle angle = MoveAngle.Down;
    private bool move;
    protected virtual void NormalAction()
    {
        if (!move)
        {
            if (actionRange.OnActionRange)
            {
                testCount++;
                if (testCount > 600)
                {
                    int a = Random.Range(0, 4);
                    switch (a)
                    {
                        case 0:
                            angle = MoveAngle.Up;
                            break;
                        case 1:
                            angle = MoveAngle.Left;
                            break;
                        case 2:
                            angle = MoveAngle.Right;
                            break;
                        case 3:
                            angle = MoveAngle.Down;
                            break;
                        default:
                            break;
                    }
                    move = true;
                }
            }
            else
            {
                testCount = 0;
                move = false;
                moveDir = spawnPoint.position - transform.position;
                moveX = moveDir.normalized.x * moveSpeed;
                moveY = moveDir.normalized.y * moveSpeed;
            }
        }
        else
        {
            switch (angle)
            {
                case MoveAngle.Up:
                    moveDir = Vector3.up;
                    break;
                case MoveAngle.Left:
                    moveDir = Vector3.left;
                    break;
                case MoveAngle.Right:
                    moveDir = Vector3.right;
                    break;
                case MoveAngle.Down:
                    moveDir = Vector3.down;
                    break;
                default:
                    break;
            }
            testCount -= 5;
            if (testCount < 0)
            {
                testCount = 0;
                move = false;
            }
            moveX = moveDir.normalized.x * moveSpeed;
            moveY = moveDir.normalized.y * moveSpeed;
        }
    }

    protected virtual void FindPlayerAction()
    {
        if (actionRange.OnActionRange)
        {
            moveDir = Player.Instance.transform.position - transform.position;
            moveX = moveDir.normalized.x * moveSpeed;
            moveY = moveDir.normalized.y * moveSpeed;
        }
        else
        {

        }
    }
}
