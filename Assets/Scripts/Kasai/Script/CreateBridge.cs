using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour
{
    public static CreateBridge Instance { get; private set; }
    [SerializeField] GameObject m_bridge;
    [SerializeField] float m_bridgeLength = 4;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BridgeCreate();
        }
    }
    public void BridgeCreate()
    {
        GameObject bridge;
        if (Player.Instance.Down())
        {
            return;
        }
        bridge = Instantiate(m_bridge);
        bridge.transform.position = Player.Instance.transform.position + new Vector3(0, -m_bridgeLength, 0);
        NewItemManager.Instance.SubItem(67,1);
    }



    public void BridgeCreate(int m)
    {
        GameObject bridge;
        //NewItemManager.Instance.SubItem(NewItemManager.Instance.Gettoo);
        if (Input.GetAxisRaw("Vertical") == 0)
        {

            switch (Player.Instance.GetAngle())
            {
                case MoveAngle.Left:
                    switch (Player.Instance.GetAngle())
                    {
                        case MoveAngle.Left:
                            if (Player.Instance.Right())
                            {
                                return;
                            }
                            bridge = Instantiate(m_bridge);
                            bridge.transform.rotation = Quaternion.FromToRotation(Vector2.up, Vector2.left);
                            bridge.transform.position = Player.Instance.transform.position + new Vector3(-m_bridgeLength, -1, 0);
                            break;
                        case MoveAngle.Right:
                            if (Player.Instance.Left())
                            {
                                return;
                            }
                            bridge = Instantiate(m_bridge);
                            bridge.transform.rotation = Quaternion.FromToRotation(Vector2.up, Vector2.right);
                            bridge.transform.position = Player.Instance.transform.position + new Vector3(-m_bridgeLength, -1, 0);
                            break;
                        default:
                            break;
                    }
                    break;
                case MoveAngle.Right:
                    switch (Player.Instance.GetAngle())
                    {
                        case MoveAngle.Left:
                            if (Player.Instance.Left())
                            {
                                return;
                            }
                            bridge = Instantiate(m_bridge);
                            bridge.transform.rotation = Quaternion.FromToRotation(Vector2.up, Vector2.left);
                            bridge.transform.position = Player.Instance.transform.position + new Vector3(m_bridgeLength, -1, 0);
                            break;
                        case MoveAngle.Right:
                            if (Player.Instance.Right())
                            {
                                return;
                            }
                            bridge = Instantiate(m_bridge);
                            bridge.transform.rotation = Quaternion.FromToRotation(Vector2.up, Vector2.right);
                            bridge.transform.position = Player.Instance.transform.position + new Vector3(m_bridgeLength, -1, 0);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (Player.Instance.Up())
                {
                    return;
                }
                bridge = Instantiate(m_bridge);
                bridge.transform.position = Player.Instance.transform.position + new Vector3(0, m_bridgeLength - 1, 0);
            }
            else
            {
                if (Player.Instance.Down())
                {
                    return;
                }
                bridge = Instantiate(m_bridge);
                bridge.transform.position = Player.Instance.transform.position + new Vector3(0, -m_bridgeLength, 0);
            }
        }
    }
}
