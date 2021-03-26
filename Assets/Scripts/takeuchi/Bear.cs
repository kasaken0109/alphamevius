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
}
