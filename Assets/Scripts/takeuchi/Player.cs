using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MoveAngle
{
    Left,
    Right,
}
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    /// <summary> 移動速度 </summary>
    [SerializeField] private float moveSpeed = 1.0f;
    /// <summary> X座標移動力 </summary>
    private float moveX;
    /// <summary> Y座標移動力 </summary>
    private float moveY;
    /// <summary> Playerの物理 </summary>
    private Rigidbody2D rB = null;
    /// <summary> Playerの向き </summary>
    private MoveAngle angle;
    private bool angleChange;
    /// <summary> 行動可能かのフラグ </summary>
    private bool action;
    private bool attack;
    private bool move;
    private bool arrowMode;
    private bool arrow;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] GameObject attackScale;
    private float attackTimer;
    private float damageTimer;
    [SerializeField] Animator playerAnimation = null;
    Vector2 arrowDir = Vector2.right;
    private bool up;
    private bool down;
    private bool left;
    private bool right;
    [SerializeField] CheckFloor upFloor;
    [SerializeField] CheckFloor downFloor;
    [SerializeField] CheckFloor leftFloor;
    [SerializeField] CheckFloor rightFloor;
    [SerializeField] GameObject torchLight;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        action = true;
        move = true;
        attackScale.SetActive(false);
        angleChange = true;
    }

    void Update()
    {
        if (!action)
        {
            return;
        }
        if (angleChange)
        {
            if (angle == MoveAngle.Right)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            angleChange = false;
        }
        if (playerAnimation && attack)
        {
            playerAnimation.SetBool("Attack", false);
        }
        if (Input.GetButtonDown("Jump") && attackTimer <= 0)
        {                
            if (playerAnimation)
            {
                if (arrowMode)
                {
                    playerAnimation.SetBool("Arrow", true);
                    arrow = true;
                    rB.velocity = Vector2.zero;
                }
                else
                {
                    playerAnimation.SetBool("Attack", true);
                }
            }
        }
        if (arrow)
        {
        //    Vector2 myPos = transform.position;
        //    Vector3 mousePos = Input.mousePosition;
        //    mousePos.z = -10;
        //    Vector2 cPos = Camera.main.ScreenToWorldPoint(mousePos);
        //    arrowDir = -cPos - myPos;
            if (arrowDir.normalized.x > 0)
            {
                if (angle != MoveAngle.Right)
                {
                    angle = MoveAngle.Right;
                    angleChange = true;
                }
            }
            else
            {
                if (angle != MoveAngle.Left)
                {
                    angle = MoveAngle.Left;
                    angleChange = true;
                }
            }
        }
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0.3f)
            {
                attackScale.SetActive(false);
            }
        }
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                if (playerAnimation)
                {
                    playerAnimation.SetBool("Damage", false);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (!action || !move)
        {
            rB.velocity = Vector2.zero;
            return;
        }
        right = rightFloor.ONWalkable();
        left = leftFloor.ONWalkable();
        up = upFloor.ONWalkable();
        down = downFloor.ONWalkable();
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (arrowMode)
            {
                if (arrow)
                {
                    playerAnimation.SetBool("Arrow", false);
                    arrow = false;
                }
            }
            if (playerAnimation)
            {
                playerAnimation.SetBool("Move", true);
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveX = 1;
                if (angle != MoveAngle.Right)
                {
                    angle = MoveAngle.Right;
                    angleChange = true;
                }
                switch (angle)
                {
                    case MoveAngle.Left:
                        if (!left)
                        {
                            moveX = 0;
                        }
                        break;
                    case MoveAngle.Right:
                        if (!right)
                        {
                            moveX = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveX = -1;
                if (angle != MoveAngle.Left)
                {
                    angle = MoveAngle.Left;
                    angleChange = true;
                }
                switch (angle)
                {
                    case MoveAngle.Left:
                        if (!right)
                        {
                            moveX = 0;
                        }
                        break;
                    case MoveAngle.Right:
                        if (!left)
                        {
                            moveX = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                moveY = 1;
                if (!up)
                {
                    moveY = 0;
                }
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                moveY = -1;
                if (!down)
                {
                    moveY = 0;
                }
            }
        }
        else
        {
            if (playerAnimation)
            {
                playerAnimation.SetBool("Move", false);
            }
        }
        if (playerAnimation)
        {
            playerAnimation.SetBool("Collection", false);
        }
        rB.velocity = new Vector2(moveX, moveY).normalized * moveSpeed;
        moveX = 0;
        moveY = 0;
    }
    public void MoveStop()
    {
        rB.velocity = Vector2.zero;
        move = false;
    }
    public void MoveStart()
    {
        move = true;
    }
    /// <summary>
    /// プレイヤーを行動不能にする
    /// </summary>
    public void ActionStop()
    {
        rB.velocity = Vector2.zero;
        action = false;
    }
    public void ArrowShot(Vector2 dir)
    {
        if (arrow)
        {
            GameObject arrowObiect = Instantiate(arrowPrefab);
            arrowObiect.transform.position = attackScale.transform.position;
            arrowObiect.GetComponent<Arrow>().SetArrowDir(dir);
            playerAnimation.SetBool("Arrow", false);
            arrow = false;
            move = true;
            attackTimer = 0.5f;
        }
    }
    public void PlayerAttack()
    {
        attackScale.SetActive(true);
        attackTimer = 0.5f;
        attack = true;
    }
    /// <summary>
    /// プレイヤーを行動可能にする
    /// </summary>
    public void ActionStart() { action = true; }
    public void EquipmentArrow() { arrowMode = true; }
    public void NoneEquipmentArrow() { arrowMode = false; }
    public void EquipmentTorch() 
    {
        if (torchLight)
        {
            torchLight.SetActive(true);
        }
        playerAnimation.SetBool("Torch", true); 
    }
    public void NoneEquipmentTorch()
    {
        if (torchLight)
        {
            torchLight.SetActive(false);
        }
        playerAnimation.SetBool("Torch", false); 
    }
    public void CatchItem() { playerAnimation.SetBool("Collection", true); }
    public void Damage()
    {
        playerAnimation.SetBool("Damage", true);
        damageTimer = 0.1f;
        EffectManager.PlayEffect(EffectType.Hit, transform.position);
    }

    public MoveAngle GetAngle()
    {
        return angle;
    }
    public bool Left() { return left; }
    public bool Right() { return right; }
    public bool Up() { return up; }
    public bool Down() { return down; }
}
