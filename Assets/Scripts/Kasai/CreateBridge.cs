using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour
{
    [SerializeField] GameObject m_bridge;
    [SerializeField] GameObject m_bridgeCollider;
    bool m_touchFlag = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ItemManage.Instance.itemList[ItemEnum.Bridge]);
        if (ItemManage.Instance.itemList[ItemEnum.Bridge] == 1 && Input.GetButtonDown("Craft") && m_touchFlag)
        {
            m_bridge.SetActive(true);
            m_bridgeCollider.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "KeyCollider")
        {
            Debug.Log("プレイヤーが入った");
            m_touchFlag = true;
        }
    }
}
