using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBridge : MonoBehaviour
{
    //public static XBridge Instance { get; private set; }
    public bool CanCreate = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanCreate)
        {
            return;
        }
        if (collision.tag == "NotBuild")
        {
            CanCreate = true;
            NewItemManager.Instance.AddItem(23, 1);
            ZInventoryManager.Instance.ToolGet(23);
            MessgaeManager.ViweMessage("ここでは橋をかけられない");
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanCreate)
        {
            return;
        }
        if (collision.tag == "NotBuild")
        {
            CanCreate = true;
            NewItemManager.Instance.AddItem(23, 1);
            ZInventoryManager.Instance.ToolGet(23);
            MessgaeManager.ViweMessage("ここでは橋をかけられない");
            Destroy(this.gameObject); 
        }
    }
}
