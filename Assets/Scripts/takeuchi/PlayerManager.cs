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
    /// <summary> 初期攻撃力 </summary>
    [SerializeField] int startPower;
    /// <summary> 現在の体力 </summary>
    public int CurrentHP { get; private set; }
    /// <summary> 現在の空腹度 </summary>
    public int CurrentHunger { get; private set; }
    /// <summary> 現在の水分値 </summary>
    public int CurrentHydrate { get; private set; }
    /// <summary> 現在の攻撃力 </summary>
    public int CurrentPower { get; private set; } = 40;
    /// <summary> 基礎攻撃力 </summary>
    public int BasePower { get; private set; }
    /// <summary> ステータス反映初期時間：空腹 </summary>
    [SerializeField] int startOneHungerTime = 9;
    /// <summary> ステータス反映時間：空腹 </summary>
    int oneHungerTime;
    /// <summary> 反映時間カウント：空腹 </summary>
    int hungerCounter;
    /// <summary> ステータス反映初期時間：水分 </summary>
    [SerializeField] int startOneDehydrationTime = 6;
    /// <summary> ステータス反映時間：水分 </summary>
    int oneDehydrationTime;
    /// <summary> 反映時間カウント：空腹 </summary>
    int hydrateCounter;
    /// <summary> 状態異常フラグ：飢餓 </summary>
    public bool StatusEffectHunger { get; private set; }
    /// <summary> 状態異常反映時間：飢餓 </summary>
    [SerializeField] int sEHungerTime = 10;
    /// <summary> 状態異常カウント：飢餓 </summary>
    int sEHungerCounter;
    /// <summary> 状態異常フラグ：脱水 </summary>
    public bool StatusEffectDehydration { get; private set; }
    /// <summary> 状態異常反映時間：脱水 </summary>
    [SerializeField] int sEDehydrationTime = 10;
    /// <summary> 状態異常カウント：脱水 </summary>
    int sEDehydrationCounter;
    [SerializeField] int[] needEXPList;
    int maxLevel;
    public int CurrentLevel { get; private set; }
    public int TotalEXP { get; private set; }
    public ToolType EquipmentTool { get; private set; } = ToolType.None;
    public int EquipmentPower { get; private set; } = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        #region ステータス関係の初期化
        CurrentHP = playerMaxHP;
        CurrentHunger = playerMaxHunger;
        CurrentHydrate = playerMaxHydrate;
        oneHungerTime = startOneHungerTime;
        oneDehydrationTime = startOneDehydrationTime;
        maxLevel = needEXPList.Length;
        #endregion
    }
    /// <summary>
    /// ゲーム内時間一秒ごとにステータス関係を更新する
    /// </summary>
    public void OneSecondStatusUpdate()
    {
        hungerCounter++;
        if (hungerCounter >= oneHungerTime)
        {
            hungerCounter = 0;
            ExpendHunger(1);
        }
        hydrateCounter++;
        if (hydrateCounter >= oneDehydrationTime)
        {
            hydrateCounter = 0;
            ExpendHydrate(1);
        }
        if (StatusEffectHunger)
        {
            sEHungerCounter++;
            if (sEHungerCounter >= sEHungerTime)
            {
                sEHungerCounter = 0;
                Damage(1);
            }
        }
        if (StatusEffectDehydration)
        {
            sEDehydrationCounter++;
            if (sEDehydrationCounter >= sEDehydrationTime)
            {
                sEDehydrationCounter = 0;
                Damage(1);
            }
        }
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
    /// 満腹度を減少させる
    /// </summary>
    /// <param name="point"></param>
    public void ExpendHunger(int point)
    {
        CurrentHunger -= point;
        if (CurrentHunger <= 0)
        {
            CurrentHunger = 0;
            StatusEffectHunger = true;
        }
    }
    /// <summary>
    /// 水分値を減少させる
    /// </summary>
    /// <param name="point"></param>
    public void ExpendHydrate(int point)
    {
        CurrentHydrate -= point;
        if (CurrentHydrate <= 0)
        {
            CurrentHydrate = 0;
            StatusEffectDehydration = true;
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
        hungerCounter = 0;
        StatusEffectHunger = false;
        sEHungerCounter = 0;
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
        hydrateCounter = 0;
        StatusEffectDehydration = false;
        sEDehydrationCounter = 0;
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
    public void SetOneDehydrationTime(int time) { oneDehydrationTime = time; }
    public void SetOneHungerTime(int time) { oneHungerTime = time; }
    public void EXPGet(int exp)
    {
        if (CurrentLevel >= maxLevel)
        {
            return;
        }
        TotalEXP += exp;
        if (needEXPList[CurrentLevel] >= TotalEXP)
        {
            CurrentLevel++;            
        }
    }
    public void SetEquipmentTool(NewItem item)
    {
        EquipmentTool = item.GetToolType();
        SetPower(item.GetAttackPoint());
        EquipmentPower = item.GetEfficiency();
        Debug.Log(EquipmentTool + "を装備した");
    }
    public void PurgeEquipmentTool()
    {
        EquipmentTool = ToolType.None; 
        SetPower(BasePower);
        EquipmentPower = 0;
    }
}
