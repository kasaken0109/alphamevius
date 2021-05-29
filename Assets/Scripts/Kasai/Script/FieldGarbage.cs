using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGarbage : MonoBehaviour
{
    [SerializeField] protected int itemID;
    bool getF;
    float getTimer = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (getF || !Player.Instance.GetAction())
            {
                return;
            }
            if (!ZInventoryManager.Instance.FullInventory)
            {
                getF = true;
                Player.Instance.CatchItem();
                StartCoroutine(GetGarbage());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (getF || !Player.Instance.GetAction())
            {
                return;
            }
            if (!ZInventoryManager.Instance.FullInventory)
            {
                getF = true;
                Player.Instance.CatchItem();
                StartCoroutine(GetGarbage());
            }

        }
    }
    private void OnEnable()
    {
        getF = false;
    }
    private IEnumerator GetGarbage()
    {
        while (getTimer > 0)
        {
            getTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        NewItemManager.Instance.AddItem(itemID, 1);
        ZInventoryManager.Instance.ToolGet(itemID);
        this.gameObject.SetActive(false);
        getTimer = 0.5f;
    }
}
