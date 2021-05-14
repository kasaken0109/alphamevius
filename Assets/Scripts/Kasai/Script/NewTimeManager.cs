using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static NewTimeManager Instance { get; private set; }
    Text m_timeText = null;
    [SerializeField] int m_limitTime = 5;
    private float m_time;
    private float m_second = 0;
    private int m_minutes;
    private int m_hour = 0;
    private GameStatus gameStatus;
    Color panelColor;
    public enum GameStatus
    {
        START,
        PAUSE,
        RESUME,
        GAMEOVER,
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m_timeText = GameObject.Find("TimeText").GetComponent<Text>();
        gameStatus = GameStatus.START;
        m_minutes = m_limitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_second <= 0)
        {
            if (m_minutes == 0)
            {
                gameStatus = GameStatus.GAMEOVER;
            }
            else
            {
                m_second = 59.99f;
                m_minutes--;
            }
        }
        if (gameStatus == GameStatus.RESUME || gameStatus == GameStatus.START)
        {
            m_second -= Time.deltaTime;
        }
        m_timeText.text = string.Format($"{m_minutes:00} : {Mathf.FloorToInt(m_second):00}");

        if (gameStatus == GameStatus.GAMEOVER)
        {
            m_timeText.text = "GAMEOVER";
        }
    }

    public GameStatus GetGameStatus()
    {
        return gameStatus;
    }
}
