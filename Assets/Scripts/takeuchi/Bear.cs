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
}
