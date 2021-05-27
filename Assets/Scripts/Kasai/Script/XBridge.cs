using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBridge : MonoBehaviour
{
    public static XBridge Instance { get; private set; }
    public bool CanCreate = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "NotBuild")
        {
            Destroy(this.gameObject);
            CanCreate = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "NotBuild")
        {
            Destroy(this.gameObject);
            CanCreate = false;
        }
    }
}
