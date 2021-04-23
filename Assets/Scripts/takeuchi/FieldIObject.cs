using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldIObject : MonoBehaviour
{
    [SerializeField] protected ItemEnum ObjectType;
    [SerializeField] protected int strengthPoint = 5;
    [SerializeField] protected ItemEnum[] DropItems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            if (ObjectType == ItemManage.Instance.GetEquipment())
            {
                strengthPoint--;
                HaveItemManager.Instance.UseWeapon();
                if (strengthPoint <= 0)
                {
                    FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
