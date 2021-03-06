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
    [SerializeField] protected int power = 5;
    /// <summary> 出現位置 </summary>
    [SerializeField] protected Transform spawnPoint;
    /// <summary> 描画される画像 </summary>
    [SerializeField] protected GameObject creature;
    /// <summary> 落とすアイテム </summary>
    [SerializeField] protected MaterialType[] haveItems;
    /// <summary> 行動可能かのフラグ </summary>
    protected bool action;
    protected bool moveStop;
    [SerializeField] protected ActionRange actionRange;
    [SerializeField] protected ActionRange searchRange;
    [SerializeField] protected ActionRange attackRange;
    [SerializeField] protected float attackInterval = 1f;
    protected float attackTimer;
    protected Rigidbody2D rB = null;
    /// <summary> 移動速度 </summary>
    [SerializeField] protected float moveSpeed = 1.0f;
    /// <summary> X座標移動力 </summary>
    protected float moveX;
    /// <summary> Y座標移動力 </summary>
    protected float moveY;
    protected Vector3 moveDir = Vector3.zero;
    protected CircleCollider2D circleCollider;
    [SerializeField] protected float stanTime = 1f;
    protected float stanTimer;
    protected bool stan;
    [SerializeField] protected Animator CreaturesAnimation = null;
    [SerializeField] protected GameObject haveGarbage = null;
    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        actionRange.SetOwner(this);
        CurrentHP = maxHP;
        ActionStart();
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
        SoundManager.Instance.PlayObjectSE(6);
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
        if (haveGarbage)
        {
            Instantiate(haveGarbage).transform.position = transform.position;
        }
        rB.velocity = Vector3.zero;
        circleCollider.enabled = false;
        if (CreaturesAnimation)
        {
            CreaturesAnimation.SetBool("Dead", true);
        }
    }
    /// <summary>
    /// Creatureを行動不能にする
    /// </summary>
    public virtual void ActionStop() { action = false; }
    /// <summary>
    /// Creatureを行動可能にする
    /// </summary>
    public virtual void ActionStart() { action = true; }
    [SerializeField] protected float actionTime = 3f;
    private float actionTimer;
    private MoveAngle angle = MoveAngle.Down;
    private bool move;
    protected virtual void NormalAction()
    {
        if (moveStop)
        {
            return;
        }
        if (!move)
        {
            actionTimer += Time.deltaTime;
            if (actionTimer >= actionTime)
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
                if (actionRange.ONCreatures())
                {
                    switch (angle)
                    {
                        case MoveAngle.Up:
                            moveDir = Vector3.up;
                            break;
                        case MoveAngle.Left:
                            moveDir = Vector3.left;
                            transform.localScale = new Vector3(1, 1, 1);
                            break;
                        case MoveAngle.Right:
                            moveDir = Vector3.right;
                            transform.localScale = new Vector3(-1, 1, 1);
                            break;
                        case MoveAngle.Down:
                            moveDir = Vector3.down;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    moveDir = spawnPoint.position - transform.position;
                    if (moveDir.normalized.x > 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
        }
        else
        {
            actionTimer -= 5f * Time.deltaTime;
            if (actionTimer <= 0)
            {
                actionTimer = 0;
                move = false;
            }
            moveX = moveDir.normalized.x * moveSpeed;
            moveY = moveDir.normalized.y * moveSpeed;
        }
    }
    protected virtual void FindPlayerAction()
    {
        
        if (actionRange.ONCreatures())
        {
            if (moveStop)
            {
                moveX = 0;
                moveY = 0;
                return;
            }
            moveDir = Player.Instance.transform.position - transform.position;
            if (moveDir.normalized.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            moveX = moveDir.normalized.x * moveSpeed;
            moveY = moveDir.normalized.y * moveSpeed;
        }
        else
        {
            if (moveStop)
            {
                moveX = 0;
                moveY = 0;
                return;
            }
            NormalAction();
        }
    }
    protected virtual void AttackAction()
    {
        if (CreaturesAnimation)
        {
            CreaturesAnimation.SetBool("Attack", true);
        }
    }
    public virtual void AttackPlayer()
    {
        if (attackRange)
        {
            SoundManager.Instance.PlayObjectSE(3);
            if (attackRange.ONPlayer())
            {
                PlayerManager.Instance.Damage(power);
            }
        }
    }
    public void MoveStop()
    {
        moveStop = true;
        rB.velocity = Vector2.zero;
    }
    public void MoveStart()
    {
        moveStop = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack" && !stan)
        {
            stan = true;
            stanTimer = stanTime;
            Damage(PlayerManager.Instance.CurrentPower);
            EffectManager.PlayEffect(EffectType.Hit, transform.position);
        }
    }

    public int GetPower() { return power; }
}
