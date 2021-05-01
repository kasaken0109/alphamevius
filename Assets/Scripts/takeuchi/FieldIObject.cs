using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldIObject : MonoBehaviour
{
    [SerializeField] protected ToolType ObjectType;
    [SerializeField] protected int strengthPoint = 120;
    [SerializeField] protected MaterialType[] DropItems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            if (ObjectType == PlayerManager.Instance.EquipmentTool)
            {
                strengthPoint -= PlayerManager.Instance.EquipmentPower;
                if (strengthPoint <= 0)
                {
                    FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
