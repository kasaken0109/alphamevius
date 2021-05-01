using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRayCastController : MonoBehaviour
{
    public bool m_isAbleMove;
    [SerializeField] LayerMask m_layerMask = 0;
    [SerializeField] GameObject m_player;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_player.transform.position);
        float maxDistance = 1;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, m_layerMask);
        Debug.DrawLine(m_player.transform.position,m_player.transform.position + new Vector3(0, maxDistance, 0));
        if (!hit)
        {
            return;
        }
        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        if (hit.collider.tag == "NotWakable")
        {
            Debug.Log(hit.collider.name);
            m_isAbleMove = false;
        }
        else
        {
            Debug.Log("NotHit");
            m_isAbleMove = true;
        }
    }
}
