using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGarbage : MonoBehaviour
{
    [SerializeField] protected int itemID;
    bool getF;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (getF)
            {
                return;
            }
            if (!ZInventoryManager.Instance.FullInventory)
            {
                getF = true;
                NewItemManager.Instance.AddItem(itemID, 1);
                ZInventoryManager.Instance.ToolGet(itemID);
                Player.Instance.CatchItem();
                EffectManager.PlayEffect(EffectType.Hit, transform.position);
                this.gameObject.SetActive(false);
                getF = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (getF)
            {
                return;
            }
            if (!ZInventoryManager.Instance.FullInventory)
            {
                getF = true;
                NewItemManager.Instance.AddItem(itemID, 1);
                ZInventoryManager.Instance.ToolGet(itemID);
                Player.Instance.CatchItem();
                EffectManager.PlayEffect(EffectType.Hit, transform.position);
                this.gameObject.SetActive(false);
                getF = false;
            }

        }
    }
    private void OnEnable()
    {
        getF = false;
    }
}
