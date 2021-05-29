using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 攻撃時の SE を鳴らす
    /// </summary>
    public void PlayAttackSE()
    {
        SoundManager.Instance.PlayAttack();
    }
    /// <summary>
    /// プレイヤー被ダメージ時の SE を鳴らす
    /// </summary>
    public void PlayGetDamageSE()
    {
        SoundManager.Instance.PlaySeGetDamage();
    }

    /// <summary>
    /// アイテム取得時の SE を鳴らす
    /// </summary>
    public void PlayGetItemSE()
    {
        SoundManager.Instance.PlayGetItem();
    }

    /// <summary>
    /// アイテム取得時の SE を鳴らす
    /// </summary>
    public void PlayWalk()
    {
        //Debug.Log("walk!walk!");
        SoundManager.Instance.PlayWalk();
    }
}
