using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creaturesを継承したクモのクラス
/// </summary>
public class Spider : Creatures
{
    private void Update()
    {
        if (TimeManager.DayStatus.NOON == TimeManager.Instance.GetDayStatus())
        {
            Dead();
        }
        if (Input.GetButtonDown("Jump") && TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT)
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
    public override void StartSpawn()
    {
        transform.position = spawnPoint.position;
        CurrentHP = maxHP;
        creature.SetActive(true);
        circleCollider.enabled = true;
        ActionStart();
    }
    protected override void Dead()
    {
        ActionStop();
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT)
        {
            FieldItemManager.Instance.DropMaterial(haveItems, transform.position);
        }
        //FieldItemManager.Instance.DropMaterial(haveMaterial, transform.position);
        //foreach (var item in haveItems)
        //{
        //    FieldItemManager.Instance.DropItem(item, transform.position);
        //}
        //creature.SetActive(false);
        rB.velocity = Vector3.zero;
        circleCollider.enabled = false;
        if (CreaturesAnimation)
        {
            CreaturesAnimation.SetBool("Dead", true);
        }
    }
}
