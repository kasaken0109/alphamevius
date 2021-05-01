using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary> 行動範囲内に生き物いる場合trueを返す </summary>
    public bool OnActionRange { get; private set; }
    /// <summary> 行動範囲内にプレイヤー動ける範囲がある場合trueを返す </summary>
    /// 
    //private void Start()
    //{
    //    ONWalkable();
    //    Debug.Log(GoWalkable);
    //}
    public bool GoWalkable { get; private set; }   
    private bool PEnter = false;
    private bool PStay = false;
    private bool PExit = false;
    public bool ONWalkable()
    {
        if (PEnter || PStay)
        {
            GoWalkable = true;
        }
        if (PExit)
        {
            GoWalkable = false;
        }
        PEnter = false;
        PStay = false;
        PExit = false;
        return GoWalkable;
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Walkable")
        {
            PEnter = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Walkable")
        {
            PStay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Walkable")
        {
            PExit = true;
        }
    }
}
