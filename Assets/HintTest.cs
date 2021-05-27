using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTest : MonoBehaviour
{
    [SerializeField] protected MaterialType[] DropItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            ObjectShaker.Instance.ShakeObject(gameObject);
            EffectManager.PlayEffect(EffectType.Hit, transform.position);

            FieldItemManager.Instance.DropMaterial(DropItem, transform.position);
            gameObject.SetActive(false);


        }
    }
}
