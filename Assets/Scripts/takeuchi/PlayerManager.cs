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
    /// <summary> 現在の攻撃力 </summary>
    public int CurrentPower { get; private set; } = 40;
    private void Awake()
    {
        Instance = this;
    }
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
    public void SetPower(int power)
    {
        CurrentPower = power; 
    }
    /// <summary>
    /// HPを回復する
    /// </summary>
    /// <param name="point"></param>
    public void HealingHP(int point)
    {
        CurrentHP += point;
        if (CurrentHP > playerMaxHP)
        {
            CurrentHP = playerMaxHP;
        }
    }
    /// <summary>
    /// 空腹度を回復する
    /// </summary>
    /// <param name="point"></param>
    public void HealingHunger(int point)
    {
        CurrentHunger += point;
        if (CurrentHunger > playerMaxHunger)
        {
            CurrentHunger = playerMaxHunger;
        }
    }
    /// <summary>
    /// 水分値を回復する
    /// </summary>
    /// <param name="point"></param>
    public void HealingHydrate(int point)
    {
        CurrentHydrate += point;
        if (CurrentHydrate > playerMaxHydrate)
        {
            CurrentHydrate = playerMaxHydrate;
        }
    }
    /// <summary> 最大HPを返す </summary>
    public int GetMaxHP() { return playerMaxHP; }
    /// <summary> 最大空腹度を返す </summary>
    public int GetMaxHunger() { return playerMaxHunger; }
    /// <summary> 最大水分値を返す </summary>
    public int GetMaxHydrate() { return playerMaxHydrate; }
}
