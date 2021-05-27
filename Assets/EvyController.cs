using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EvyController : MonoBehaviour
{
    [SerializeField] float m_moveDistance = 3;
    [SerializeField] float m_moveSpeed = 0.5f;
    [SerializeField] Transform m_target;
    Vector3 m_origin;
    // Start is called before the first frame update
    void Start()
    {
        m_origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
