using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ItemManage.Instance.itemList[ItemEnum.Chicken]++;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ItemManage.Instance.itemList[ItemEnum.Chicken]--;
        }
    }
}
