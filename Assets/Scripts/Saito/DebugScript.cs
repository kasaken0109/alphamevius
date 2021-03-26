using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    List<int> list = new List<int>();
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ItemManage.Instance.itemList[ItemEnum.SmallKnife]++;
        }
    }
}
