using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    //[SerializeField]Text text = null;
    [SerializeField] public float timeRate = 0.5f;
    [SerializeField] int timeScale = 10;
    [SerializeField] GameObject m_menu = null;
    [SerializeField] GameObject m_drift = null;
    [SerializeField] GameObject m_sun = null;
    [SerializeField] GameObject m_moon = null;
    [SerializeField] Transform m_spawn = null;
    [SerializeField] float m_gameSpeed = 1;
    [SerializeField] Image m_panel;
    //bool m_dayswitch = false;
    ItemBaseMain itemWood;
    ItemBaseMain itemDurableIvy;
    ItemCraft m_craft;
    public float m_time;
    private float m_secondCount;
    public float m_second;
    public int m_hour = 0;
    public int m_dayNum = 1;
    DayStatus dayStatus;
    Color panelColor;
    // Start is called before the first frame update
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
        dayStatus = DayStatus.NOON;
        panelColor = m_panel.color;
        m_drift.SetActive(false);
        m_hour = 6;
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_time += Time.deltaTime / 60;
        m_secondCount += Time.deltaTime;
        m_time += Time.deltaTime;
        m_second += Time.deltaTime;
        if (m_second >= 30f / m_gameSpeed)
        {
            m_hour += 1;
            if (m_hour == 6)
            {
                m_drift.SetActive(true);
            }
            m_second = 0;
        }
        if (m_hour == 24)
        {
            m_dayNum += 1;
            m_hour = 0;
        }

        if (m_hour >= 0 && m_hour <= 6 || m_hour >= 18 && m_hour <= 24)
        {
            dayStatus = DayStatus.NIGHT;
            if(panelColor.a < 0.9f)
            {
                panelColor.a += 0.01f * m_gameSpeed;
                m_panel.color = panelColor;
            }
            
            //text.text = m_dayNum + "日目　夜:" + m_hour;
        }
        else
        {
            dayStatus = DayStatus.NOON;
            if (panelColor.a > 0f)
            {
                panelColor.a -= 0.01f * m_gameSpeed;
                if (panelColor.a <= 0)
                {
                    panelColor.a = 0;
                }
                m_panel.color = panelColor;
            }
            //text.text = m_dayNum + "日目　昼:" + m_hour;
        }

        if (m_secondCount >= 40f * m_gameSpeed)
        {
            m_secondCount = 0;
            PlayerManager.Instance.OneSecondStatusUpdate();
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
    }
    public DayStatus GetDayStatus()
    {
        return dayStatus;
    }
}
