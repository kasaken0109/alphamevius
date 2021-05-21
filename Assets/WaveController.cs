using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WaveController : MonoBehaviour
{
    [SerializeField] float m_moveDintance = 2f;
    [SerializeField] float m_moveTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wave();
    }

    void Wave()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(Vector3.forward * m_moveDintance, m_moveTime))
                .SetDelay(m_moveTime)
                .Append(transform.DOLocalMove(Vector3.back * m_moveDintance, m_moveTime))
                .SetLoops(-1);

        sequence.Play();
    }
}
