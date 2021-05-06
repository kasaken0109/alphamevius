using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XTestItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            XTestItemCollector.Instanse.ItemGet();
            Destroy(this.gameObject);
        }
    }
}
