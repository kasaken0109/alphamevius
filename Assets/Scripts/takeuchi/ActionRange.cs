using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRange : MonoBehaviour
{
    /// <summary> 行動範囲内に生き物いる場合trueを返す </summary>
    public bool OnActionRange { get; private set; }
    /// <summary> 対象の生き物 </summary>
    Creatures owner;
    /// <summary> 行動範囲内にプレイヤーがいる場合trueを返す </summary>
    public bool InPlayer { get; private set; }
    /// <summary>
    /// 縄張りの主を設定する
    /// </summary>
    /// <param name="owner"></param>
    public void SetOwner(Creatures owner)
    {
        this.owner = owner;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!OnActionRange)
        {
            if (collision.gameObject.GetComponent<Creatures>() == owner)
            {
                OnActionRange = true;
                return;
            }
        }
        if (!InPlayer)
        {
            if (collision.tag == "Player")
            {
                InPlayer = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!OnActionRange)
        {
            if (collision.gameObject.GetComponent<Creatures>() == owner)
            {
                OnActionRange = true;
                return;
            }
        }
        if (!InPlayer)
        {
            if (collision.tag == "Player")
            {
                InPlayer = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnActionRange)
        {
            if (collision.gameObject.GetComponent<Creatures>() == owner)
            {
                OnActionRange = false;
                return;
            }
        }
        if (InPlayer)
        {
            if (collision.tag == "Player")
            {
                InPlayer = false;
            }
        }
    }
}
