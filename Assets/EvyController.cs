using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class EvyController : MonoBehaviour
{
    [SerializeField] TimeManager timeManager = null;
    [SerializeField] bool IsNightEvy = true;
    [SerializeField] float m_moveDistance = 3;
    [SerializeField] float m_moveSpeed = 0.5f;
    [SerializeField] bool IsMoveUp = true;
    [SerializeField] Transform m_target;
    float m_moveDirection = 1;
    Animation m_anim;
    Rigidbody2D m_rb;
    Vector3 m_origin;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("GameManager").GetComponent<TimeManager>();
        m_rb = GetComponent<Rigidbody2D>();
        m_origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //timeManager.dayStatus = TimeManager.Instance.GetDayStatus();
        Debug.Log(timeManager.dayStatus);
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
        this.transform.DOMove(m_target.position,30f);
    }

    private void MoveBack()
    {
        this.transform.DOMove(m_origin, 30f);
    }

    private void Stop()
    {
        m_rb.velocity = new Vector2(0, 0);
    }
}
