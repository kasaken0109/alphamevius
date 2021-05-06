using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{    
    [SerializeField] Creatures creature;
    public void AttackPlayer()
    {
        creature.AttackPlayer();
    }
    public void MoveStop()
    {
        creature.MoveStop();
    }
    public void MoveStart()
    {
        creature.MoveStart();
    }
    public void NonActive()
    {
        this.gameObject.SetActive(false);
    }
    public void DeleteThis()
    {
        Destroy(this.gameObject);
    }
    public void PlayerAttackAction()
    {
        Player.Instance.PlayerAttack();
    }
}
