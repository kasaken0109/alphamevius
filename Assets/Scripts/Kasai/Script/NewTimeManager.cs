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
    [SerializeField] private GameStatus gameStatus;
    [SerializeField] private GameObject[] m_buttons;
    [SerializeField] Text m_gameStatusText;
    [SerializeField] private GameObject m_ui;
    private float m_time;
    private float m_second = 0;
    private int m_minutes;
    private int m_hour = 0;
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
        if (m_ui != null)
        {
            m_ui.SetActive(true);
        }
        //m_timeText = GameObject.Find("TimeText").GetComponent<Text>();
        gameStatus = GameStatus.START;
        m_minutes = m_limitTime;
        if (m_buttons != null)
        {
            foreach (var item in m_buttons)
            {
                item.SetActive(false);
            }
        }
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
        if (Input.GetButtonDown("Pause"))
        {
            if (gameStatus == GameStatus.PAUSE)
            {
                gameStatus = GameStatus.RESUME;
            }
            else
            {
                gameStatus = GameStatus.PAUSE;
            }
        }
        if (gameStatus == GameStatus.RESUME || gameStatus == GameStatus.START)
        {
            Time.timeScale = 1;
            m_gameStatusText.text = "";
            if (m_buttons != null)
            {
                foreach (var item in m_buttons)
                {
                    item.SetActive(false);
                }
            }

            m_second -= Time.deltaTime;
        }
        if (gameStatus == GameStatus.PAUSE)
        {
            m_gameStatusText.text = "Pause";
            Time.timeScale = 0;
            if (m_buttons != null)
            {
                foreach (var item in m_buttons)
                {
                    item.SetActive(true);
                }
            }
        }
        //m_timeText.text = string.Format($"{m_minutes:00} : {Mathf.FloorToInt(m_second):00}");

        if (gameStatus == GameStatus.GAMEOVER)
        {
            if (m_ui != null)
            {
                m_ui.SetActive(false);
            }
            //m_timeText.text = "00 : 00";
            Time.timeScale = 0;
            ScreenEffecter.Instance.FadeOut();
            m_gameStatusText.text = "GAMEOVER";
            if (m_buttons != null)
            {
                Debug.Log("ButtonActive");
                foreach (var item in m_buttons)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                Debug.Log("ButtonNonActive");
            }

        }
    }

    public GameStatus GetGameStatus()
    {
        return gameStatus;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

}
