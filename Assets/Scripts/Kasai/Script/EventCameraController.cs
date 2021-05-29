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
    bool IsPush = false;
    bool IsEndActiveMove = false;
    NightRemainController nightRemainController;

    private void Awake()
    {
        nightRemainController = GameObject.Find("NightObject").GetComponentInChildren<NightRemainController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_transposer = ((CinemachineVirtualCamera)m_cinemachine).GetCinemachineComponent<CinemachineTransposer>();
        m_transposer = ((CinemachineVirtualCamera)m_cinemachine);
        m_StartOffset = m_transposer.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT && IsEndActiveMove)
        {
            m_transposer.m_Lens.OrthographicSize = m_StartOffset;
            if (IsEndActiveMove)
            {
                NewTimeManager.Instance.AnimActive();
                IsEndActiveMove = false;
            }
            return;
        }
        if (TimeManager.Instance.GetDayStatus() != TimeManager.DayStatus.NIGHT && !nightRemainController.IsRemain)
        {
            if (IsPush)
            {
                if (m_transposer.m_Lens.OrthographicSize < m_zoomLength)
                {
                    ZoomUp(m_zoomSpeed);
                }
                NewTimeManager.Instance.AnimNonActive();
                IsEndActiveMove = true;
            }
            else
            {
                if (m_transposer.m_Lens.OrthographicSize > m_StartOffset)
                {
                    ZoomOut(m_zoomSpeed *3);
                    NewTimeManager.Instance.AnimNonActive();
                    IsEndActiveMove = true;
                }
                else
                {
                    
                    Debug.Log(IsEndActiveMove);
                    if (IsEndActiveMove)
                    {
                        NewTimeManager.Instance.AnimActive();
                        IsEndActiveMove = false;
                    }

                }
                //if (NewTimeManager.Instance.GetGameStatus() != NewTimeManager.GameStatus.PAUSE || NewTimeManager.Instance.GetGameStatus() != NewTimeManager.GameStatus.GAMEOVER)
                //{
                //    NewTimeManager.Instance.AnimActive();
                //}
                
            }
            
        }
        
        
    }

    public void ZoomUp(float m_zoomSpeed)
    {
        NewTimeManager.Instance.AnimNonActive();
        m_transposer.m_Lens.OrthographicSize += m_zoomSpeed;
    }

    public void ZoomOut(float m_zoomSpeed)
    {
        m_transposer.m_Lens.OrthographicSize -= m_zoomSpeed;
    }

    public void PushDown()
    {
        IsPush = true;
    }

    public void PushUp()
    {
        IsPush = false;
    }
}
