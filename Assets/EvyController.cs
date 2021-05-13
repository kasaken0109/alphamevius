using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EvyController : MonoBehaviour
{
    [SerializeField] TimeManager timeManager = null;
    [SerializeField] bool IsNightEvy = true;
    [SerializeField] float m_moveDistance = 3;
    [SerializeField] float m_moveSpeed = 0.5f;
    [SerializeField] Transform m_target;
    Vector3 m_origin;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("GameManager").GetComponent<TimeManager>();
        m_origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeManager.dayStatus = TimeManager.Instance.GetDayStatus();
        Debug.Log(timeManager.dayStatus);
        Debug.Log(Vector2.Distance(transform.localPosition, m_origin));
        if (IsNightEvy)
        {
            if (timeManager.dayStatus == TimeManager.DayStatus.NIGHT)
            {
                Debug.Log("NightActive");
                Move();
            }
            else
            {
                Debug.Log("NightNonActive");
                MoveBack();
            }
        }
        else
        {
            if (timeManager.dayStatus == TimeManager.DayStatus.NOON)
            {
                Debug.Log("NoonActive");
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
}
