using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightRemainController : MonoBehaviour
{
    public bool IsRemain = false;
    // Start is called before the first frame update
    void Start()
    {
        IsRemain = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsRemain = true;
            Debug.Log(IsRemain);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsRemain = true;
            Debug.Log(IsRemain);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsRemain = false;
        Debug.Log(IsRemain);
    }
}
