using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]Text text = null;
    [SerializeField] public float timeRate = 0.6f;
    [SerializeField] int timeScale = 10;
    public float m_time;
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
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime / 60;
        if (m_time >= timeScale * timeRate)
        {
            dayStatus = DayStatus.NIGHT;
            text.text = "夜:" + m_time;
        }
        else
        {
            dayStatus = DayStatus.NOON;
            text.text = "昼:" + m_time;
        }
    }
}
