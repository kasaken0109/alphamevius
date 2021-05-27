using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBridge : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "NotBuild")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "NotBuild")
        {
            Destroy(this.gameObject);
        }
    }
}
