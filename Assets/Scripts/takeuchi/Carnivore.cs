using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creaturesを継承した攻撃的なEnemyのクラス
/// </summary>
public class Carnivore : Creatures
{
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartSpawn();
        }
        if (!action)
        {
            return;
        }
        if (stanTimer > 0)
        {
            stanTimer -= Time.deltaTime;
            if (stanTimer <= 0)
            {
                stan = false;
            }
        }
        if (actionRange)
        {
            if (attackRange.ONPlayer())
            {
                rB.velocity = Vector3.zero;
                if (attackTimer <= 0)
                {
                    Vector2 dir = Player.Instance.transform.position - transform.position;
                    if (dir.normalized.x > 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    AttackAction();
                    attackTimer = attackInterval;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                    if (CreaturesAnimation)
                    {
                        CreaturesAnimation.SetBool("Attack", false);
                    }
                }                
            }
            else
            {
                if (CreaturesAnimation)
                {
                    CreaturesAnimation.SetBool("Attack", false);
                }
                attackTimer = 0;
            }
        }
    }
    private void LateUpdate()
    {
        if (!action)
        {
            return;
        }
        if (searchRange)
        {
            if (searchRange.ONPlayer())
            {
                FindPlayerAction();                
            }
            else
            {
                NormalAction();
            }
        }
        if (attackRange.ONPlayer())
        {
            rB.velocity = Vector2.zero;
            return;
        }
        rB.velocity = new Vector2(moveX, moveY);
        moveX = 0;
        moveY = 0;
    }
}
