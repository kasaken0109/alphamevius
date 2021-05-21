using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldIObject : MonoBehaviour
{
    [SerializeField] protected ToolType ObjectType;
    [SerializeField] protected int strengthPoint = 120;
    [SerializeField] protected MaterialType[] DropItems;
    [SerializeField] protected MaterialType[] DropItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            ObjectShaker.Instance.ShakeObject(gameObject);
            EffectManager.PlayEffect(EffectType.Hit,transform.position);
            if (ObjectType == PlayerManager.Instance.EquipmentTool)
            {
                strengthPoint -= PlayerManager.Instance.EquipmentPower;
                FieldItemManager.Instance.DropMaterial(DropItem, transform.position);

                if (strengthPoint <= 0)
                {
                    EffectManager.PlayEffect(EffectType.Smoke1, transform.position);
                    FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
