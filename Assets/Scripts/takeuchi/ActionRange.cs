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

    private bool Enter = false;
    private bool Stay = false;
    private bool Exit = false;
    public bool ONCreatures()
    {
        if (Enter || Stay)
        {
            OnActionRange = true;
        }
        else if (Exit)
        {
            OnActionRange = false;
        }
        Enter = false;
        Stay = false;
        Exit = false;

        return OnActionRange;
    }
    private bool PEnter = false;
    private bool PStay = false;
    private bool PExit = false;
    public bool ONPlayer()
    {
        if (PEnter || PStay)
        {
            InPlayer = true;
        }
        else if (PExit)
        {
            InPlayer = false;
        }
        PEnter = false;
        PStay = false;
        PExit = false;
        return InPlayer;
    }
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

        if (collision.gameObject.GetComponent<Creatures>() == owner)
        {
            Enter = true;
        }

        if (collision.tag == "Player")
        {
            PEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Creatures>() == owner)
        {
            Stay = true;
        }
        if (collision.tag == "Player")
        {
            PStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Creatures>() == owner)
        {
            Exit = true;
        }
        if (collision.tag == "Player")
        {
            PExit = true;
        }
    }
}
