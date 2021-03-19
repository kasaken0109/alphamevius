using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    [SerializeField] ItemBaseMain item;
    bool getFlag = false;

    public void DropItem(ItemBaseMain item,Vector3 pos)
    {
        this.item = item;
        transform.position = pos;
        getFlag = false;
        this.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!getFlag)
            {
                getFlag = true;
                ItemManage.Instance.GetItem(item);
                this.gameObject.SetActive(false);
            }
        }
    }
}
