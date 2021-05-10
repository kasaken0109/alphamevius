using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EvyController : MonoBehaviour
{
    [SerializeField] TimeManager timeManager = null;
    [SerializeField] bool IsNightEvy = true;
    [SerializeField] float m_moveDistance = 3;
    [SerializeField] float m_moveSpeed = 0.5f;
    Animation m_anim;
    Rigidbody2D m_rb;
    Transform m_origin;
    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animation>();
        m_rb = GetComponent<Rigidbody2D>();
        m_origin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeManager.dayStatus = TimeManager.Instance.GetDayStatus();
        if (IsNightEvy)
        {
            if (timeManager.dayStatus == TimeManager.DayStatus.NIGHT)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }
        else
        {
            if (timeManager.dayStatus == TimeManager.DayStatus.NOON)
            {
                Move();
            }
            else
            {
                Stop();
            }
        }
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, m_origin.position) <= m_moveDistance)
        {
            m_rb.velocity = new Vector2(0, m_moveSpeed);
        }
        else
        {
            m_rb.velocity = new Vector2(0, 0);
        }
    }

    private void Stop()
    {
        m_rb.velocity = new Vector2(0, 0);
    }
}
