using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            if (PlayerManager.Instance.EquipmentTool == ToolType.EmptyBottle)
            {
                NewItemManager.Instance.GetWaterBottle(PlayerManager.Instance.EquipmentPower);
            }
        }
    }
}
