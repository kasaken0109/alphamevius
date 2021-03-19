using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour
{
    [SerializeField] GameObject m_bridge;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ItemManage.Instance.itemList[ItemEnum.Bridge]);
        if (ItemManage.Instance.itemList[ItemEnum.Bridge] == 1)
        {
            m_bridge.SetActive(true);
        }
    }
}
