using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]Text text = null;
    [SerializeField] public float timeRate = 0.6f;
    [SerializeField] int timeScale = 10;
    ItemBaseMain itemWood;
    ItemBaseMain itemDurableIvy;
    public float m_time;
    int m_dayNum = 0;
    DayStatus dayStatus;
    // Start is called before the first frame update
    enum DayStatus
    {
        NOON,
        NIGHT,
    }
    void Start()
    {
        dayStatus = DayStatus.NOON;

        itemWood = new ItemBaseMain(ItemEnum.Wood);
        ItemManage.Instance.SetItem(itemWood,5);
        itemDurableIvy = new ItemBaseMain(ItemEnum.DurableIvy);
        ItemManage.Instance.SetItem(itemDurableIvy, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //m_time += Time.deltaTime / 60;
        m_time += Time.deltaTime;
        m_dayNum = ((int)m_time / timeScale) + 1;
        if ((m_time % timeScale) >= timeScale * timeRate)
        {
            dayStatus = DayStatus.NIGHT;
            text.text = m_dayNum + "日目　夜:" + m_time % timeScale;
        }
        else
        {
            dayStatus = DayStatus.NOON;
            text.text = m_dayNum + "日目　昼:" + m_time % timeScale;
        }
    }
}
