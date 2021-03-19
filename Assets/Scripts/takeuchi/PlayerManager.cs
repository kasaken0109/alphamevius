using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> ステータス関係を管理する </summary>
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    /// <summary> 体力最大値 </summary>
    [SerializeField] int playerMaxHP = 100;
    /// <summary> 空腹度最大値 </summary>
    [SerializeField] int playerMaxHunger = 100;
    /// <summary> 水分最大値 </summary>
    [SerializeField] int playerMaxHydrate = 100;
    /// <summary> 現在の体力 </summary>
    public int CurrentHP { get; private set; }
    /// <summary> 現在の空腹度 </summary>
    public int CurrentHunger { get; private set; }
    /// <summary> 現在の水分値 </summary>
    public int CurrentHydrate { get; private set; }
    private void Start()
    {
        #region 体力関係の初期化
        CurrentHP = playerMaxHP;
        CurrentHunger = playerMaxHunger;
        CurrentHydrate = playerMaxHydrate;
        #endregion
    }
    /// <summary>
    /// プレイヤーにダメージを与える
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            CurrentHP = 0;
            Dead();
        }
    }
    /// <summary>
    /// 死亡時の処理
    /// </summary>
    void Dead()
    {
        Player.Instance.ActionStop();
    }
}
