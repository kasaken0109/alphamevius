using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] GameObject attackScale;
    private float attackTimer;
    private enum MoveAngle
    {
        Left,
        Right,
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        action = true;
        attackScale.SetActive(false);
    }

    void Update()
    {
        if (action)
        {
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
            if (Input.GetButtonDown("Attack") && attackTimer <= 0)
            {
                Debug.Log("attack");
                attackScale.SetActive(true);
                attackTimer = 0.5f;
            }
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer < 0.3f)
                {
                    attackScale.SetActive(false);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (action)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    moveX = moveSpeed;
                    if (angle != MoveAngle.Right)
                    {
                        angle = MoveAngle.Right;
                        angleChange = true;
                    }
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    moveX = -moveSpeed;
                    if (angle != MoveAngle.Left)
                    {
                        angle = MoveAngle.Left;
                        angleChange = true;
                    }
                }
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    moveY = moveSpeed;
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    moveY = -moveSpeed;
                }
            }            
        }
        rB.velocity = new Vector2(moveX, moveY);
        moveX = 0;
        moveY = 0;
    }
    /// <summary>
    /// プレイヤーを行動不能にする
    /// </summary>
    public void ActionStop() { action = false; }
    /// <summary>
    /// プレイヤーを行動可能にする
    /// </summary>
    public void ActionStart() { action = true; }
}
