using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObject : MonoBehaviour
{
    [SerializeField] protected MaterialType DropItems;
    [SerializeField] private int m_dropNum = 1;
    float getTimer = 0.5f;
    bool getF;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (getF)
        {
            return;
        }
        if (collision.tag == "Player")
        {
            getF = true;
            Player.Instance.CatchItem();
            StartCoroutine(GetGarbage());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (getF)
        {
            return;
        }
        if (collision.tag == "Player")
        {
            getF = true;
            Player.Instance.CatchItem();
            StartCoroutine(GetGarbage());
        }
    }

    public MaterialType GetTouchMaterial()
    {
        return DropItems;
    }
    private IEnumerator GetGarbage()
    {
        while (getTimer > 0)
        {
            getTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (DropItems != MaterialType.None)
        {
            NewItemManager.Instance.AddItem(NewItemManager.Instance.GetMaterialId(DropItems), m_dropNum);
        }
        EffectManager.PlayEffect(EffectType.Hit, transform.position);
        this.gameObject.SetActive(false);
        getTimer = 0.5f;
    }
}
