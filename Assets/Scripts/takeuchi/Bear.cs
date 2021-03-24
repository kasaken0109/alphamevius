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
        moveX = 2;
        rB.velocity = new Vector2(moveX, moveY);
        moveX = 0;
        moveY = 0;
    }
}
