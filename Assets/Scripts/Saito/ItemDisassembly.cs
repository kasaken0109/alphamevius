using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisassembly : MonoBehaviour
{
    public ItemEnum disassemblyItem;
    public ItemEnum disassemblyData;
    public void DisassemblyItem()
    {
        if (ItemManage.Instance.itemList[disassemblyItem] > 0)
        {
            Debug.Log(disassemblyData.ToString() + "をてにいれた ");
            Materialitem item = new Materialitem(disassemblyData);
            ItemManage.Instance.GetItem(item);
        }
        else
        {
            Debug.Log("分解素材を持っていません");
        }
    }
}
