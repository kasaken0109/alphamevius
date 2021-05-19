using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EventCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCameraBase m_cinemachine = null;
    [SerializeField] float m_zoomLength = -5;
    [SerializeField] float m_zoomSpeed = 0.2f;
    float m_StartOffset;
    CinemachineVirtualCamera m_transposer;

    // Start is called before the first frame update
    void Start()
    {
        //m_transposer = ((CinemachineVirtualCamera)m_cinemachine).GetCinemachineComponent<CinemachineTransposer>();
        m_transposer = ((CinemachineVirtualCamera)m_cinemachine);
        m_StartOffset = m_transposer.m_Lens.OrthographicSize;
        Debug.Log(m_transposer);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Zoom") && TimeManager.Instance.GetDayStatus() != TimeManager.DayStatus.NIGHT)
        {
            if (m_transposer.m_Lens.OrthographicSize < m_zoomLength)
            {
                ZoomUp(m_zoomSpeed);
            }
        }
        else
        {
            if(m_transposer.m_Lens.OrthographicSize > m_StartOffset)
            {
                ZoomOut(m_zoomSpeed);
            }
        }
    }

    public void ZoomUp(float m_zoomSpeed)
    {
        m_transposer.m_Lens.OrthographicSize += m_zoomSpeed;
    }

    public void ZoomOut(float m_zoomSpeed)
    {
        m_transposer.m_Lens.OrthographicSize -= m_zoomSpeed;
    }
}
