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
            Materialitem materialitem = new Materialitem(ItemEnum.AluminumCan);
            Materialitem materialitem1 = new Materialitem(ItemEnum.PieceOfCloth);
            ItemManage.Instance.SetItem(materialitem);
            ItemManage.Instance.SetItem(materialitem1);
        }
    }
}
