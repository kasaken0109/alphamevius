using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour
{
    public static CreateBridge Instance { get; private set; }
    [SerializeField] GameObject m_bridge;
    [SerializeField] GameObject m_bridgeCollider;
    [SerializeField] ActionRange actionRange = null;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BridgeCreate()
    {
        if (actionRange.ONPlayer())
        {
            ItemManage.Instance.itemList[ItemEnum.Bridge]--;
            m_bridge.SetActive(true);
            m_bridgeCollider.SetActive(false);
        }
    }
}
