using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveItem : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int attackPoint;
    public int GetMaxHP()
    {
        return maxHP;
    }
    public int GetAttack()
    {
        return attackPoint;
    }
}
