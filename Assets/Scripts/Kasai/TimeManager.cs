using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    [SerializeField]Text text = null;
    [SerializeField] public float timeRate = 0.6f;
    [SerializeField] int timeScale = 10;
    [SerializeField] GameObject m_menu = null;
    [SerializeField] GameObject m_drift = null;
    [SerializeField] Transform m_spawn = null;
    //bool m_dayswitch = false;
    ItemBaseMain itemWood;
    ItemBaseMain itemDurableIvy;
    ItemCraft m_craft;
    public float m_time;
    public float m_second;
    public int m_hour = 0;
    public int m_dayNum = 1;
    GameObject m_gameObject;
    DayStatus dayStatus;
    // Start is called before the first frame update
    enum DayStatus
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
        itemWood = new ItemBaseMain(ItemEnum.Wood);
        ItemManage.Instance.SetItem(itemWood,5);
        itemDurableIvy = new ItemBaseMain(ItemEnum.DurableIvy);
        ItemManage.Instance.SetItem(itemDurableIvy, 5);
        m_drift.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_time += Time.deltaTime / 60;
        m_time += Time.deltaTime;
        m_second += Time.deltaTime;
        if (m_second >= 0.5f)
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

        if ((m_time / 60) >= timeScale * timeRate)
        {
            dayStatus = DayStatus.NIGHT;
            text.text = m_dayNum + "日目　夜:" + m_hour;
        }
        else
        {
            dayStatus = DayStatus.NOON;
            text.text = m_dayNum + "日目　昼:" + m_hour;
        }
        ///一時的にメニューのSetActiveを追加、後で削除予定
        //if (Input.GetButtonDown("Menu"))
        //{
        //    if (!GameObject.Find("CraftButtonCanvas"))
        //    {
        //        m_menu.SetActive(true);
        //    }
        //    else
        //    {
        //        m_menu.SetActive(false);
        //    }
        //}
    }
}
