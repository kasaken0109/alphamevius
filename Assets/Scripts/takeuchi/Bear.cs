using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Creatures
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Dead();
        }
        if (Input.GetButtonDown("Jump"))
        {
            StartSpawn();
        }
        if (stanTimer > 0)
        {
            stanTimer -= Time.deltaTime;
            if (stanTimer <= 0)
            {
                stan = false;
            }
        }
    }
    private void LateUpdate()
    {
        if (actionRange.InPlayer)
        {
            FindPlayerAction();
        }
        else
        {
            NormalAction();
        }
        rB.velocity = new Vector2(moveX, moveY);
        moveX = 0;
        moveY = 0;
    }
    public override void Damage(int damage)
    {
        stan = true;
        stanTimer = stanTime;
        base.Damage(damage);
    }
}
