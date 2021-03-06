using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    [SerializeField] GameObject m_menu = null;
    [SerializeField] GameObject []m_drift = null;
    [SerializeField] GameObject m_sun = null;
    [SerializeField] GameObject m_moon = null;
    [SerializeField] Transform m_spawn = null;
    [SerializeField] public float timeRate = 0.5f;
    [SerializeField] int timeScale = 10;
    [SerializeField] float m_gameSpeed = 1;
    [SerializeField] SpriteRenderer m_panel;
    [SerializeField] bool m_panelActive;
    [SerializeField] CutInContrl contrl;
    bool CanRespawnGerbage;
    public float m_time;
    private float m_secondCount;
    public float m_second;
    public int m_hour = 0;
    public int m_passedhour = 0;
    public int m_dayNum = 1;
    public DayStatus dayStatus;
    NightRemainController nightRemainController;
    Color panelColor;
    public enum DayStatus
    {
        NOON,
        NIGHT,
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ScreenEffecter.Instance.FadeIn();
        dayStatus = DayStatus.NOON;
        panelColor = m_panel.color;
        //m_drift.SetActive(false);
        m_hour = 6;
        ScreenEffecter.Instance.FadeIn();
        nightRemainController = GameObject.Find("NightObject").GetComponentInChildren<NightRemainController>();
        CanRespawnGerbage = false;
    }

    // Update is called once per frame
    void Update()
    {
        //m_time += Time.deltaTime / 60;
        m_secondCount += Time.deltaTime;
        m_time += Time.deltaTime;
        if (!nightRemainController.IsRemain)
        {
            m_second += Time.deltaTime;
            if (m_hour >= 0 && m_hour < 6 || m_hour >= 18 && m_hour < 24)
            {
                dayStatus = DayStatus.NIGHT;
                SetPanel();
            }
            else
            {
                dayStatus = DayStatus.NOON;
                SetPanel();
            }
        }
        else
        {
            dayStatus = DayStatus.NOON;
            SetPanel();
        }
        if (m_second >= 30f / m_gameSpeed)
        {
            m_hour += 1;
            m_passedhour += 1;
            //if (m_hour == 6)
            //{
            //    m_drift.SetActive(true);
            //}
            m_second = 0;
        }
        if (m_hour == 24)
        {
            m_dayNum += 1;
            m_hour = 0;
        }

        

        if (m_secondCount >= 1f * m_gameSpeed && NewTimeManager.Instance.GetGameStatus() != NewTimeManager.GameStatus.PAUSE)
        {
            if (!nightRemainController.IsRemain)
            {
                m_secondCount = 0;
                PlayerManager.Instance.OneSecondStatusUpdate();
            }
        }

        if (dayStatus == DayStatus.NOON)
        {
            m_moon.SetActive(false);
            m_sun.SetActive(true);
        }
        else
        {
            m_moon.SetActive(true);
            m_sun.SetActive(false);
        }
        if (m_passedhour >= 6)
        {
            CanRespawnGerbage = true;
            m_passedhour = 0;
        }

        if (m_hour % 6 == 0 && CanRespawnGerbage)
        {
            foreach (var v in m_drift)
            {
                if (!v.activeInHierarchy)
                {
                    v.SetActive(true);
                }
            }
            CanRespawnGerbage = false;
        }
    }
    public DayStatus GetDayStatus()
    {
        return dayStatus;
    }

    void SetPanel()
    {
        if (panelColor.a < 0.9f && dayStatus == DayStatus.NIGHT)
        {
            panelColor.a += 0.01f * m_gameSpeed;
            m_panel.color = panelColor;
        }
        if (panelColor.a > 0f && dayStatus == DayStatus.NOON)
        {
            panelColor.a -= 0.01f * m_gameSpeed;
            if (panelColor.a <= 0)
            {
                panelColor.a = 0;
            }
            m_panel.color = panelColor;
        }
    }
    public void PlayCutIn(int number)
    {
        contrl.PlayCutIn(number);
    }
}
