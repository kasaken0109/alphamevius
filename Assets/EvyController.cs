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
    [SerializeField] bool IsMoveUp = true;
    float m_moveDirection = 1;
    Animation m_anim;
    Rigidbody2D m_rb;
    Vector3 m_origin;
    // Start is called before the first frame update
    void Start()
    {
        if (IsMoveUp)
        {
            m_moveDirection = 1;
        }
        else
        {
            m_moveDirection = -1;
        }
        m_anim = GetComponent<Animation>();
        m_rb = GetComponent<Rigidbody2D>();
        m_origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeManager.dayStatus = TimeManager.Instance.GetDayStatus();
        Debug.Log(Vector2.Distance(transform.position, m_origin));
        if (IsNightEvy)
        {
            if (timeManager.dayStatus == TimeManager.DayStatus.NIGHT)
            {
                Move();
            }
            else
            {
                MoveBack();
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
                MoveBack();
            }
        }
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, m_origin) <= m_moveDistance)
        {
            m_rb.velocity = new Vector2(0, m_moveSpeed * m_moveDirection);
        }
        else
        {
            m_rb.velocity = new Vector2(0, 0);
        }
    }

    private void MoveBack()
    {
        if (Vector2.Distance(transform.position, m_origin) > 0)
        {
            m_rb.velocity = new Vector2(0, m_moveSpeed * -m_moveDirection);
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
