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
    [SerializeField] private GameStatus m_gamestatus;
    [SerializeField] private GameObject[] m_buttons;
    [SerializeField] Text m_gameStatusText;
    [SerializeField] private GameObject m_ui;
    private float m_time;
    private float m_second = 0;
    private int m_minutes;
    private int m_hour = 0;
    Color panelColor;
    Animator m;
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
        m = GameObject.Find("Player").GetComponentInChildren<Animator>();
        m_gamestatus = GameStatus.START;
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
        Debug.Log(m_gamestatus);
        
        if (PlayerManager.Instance.CurrentHP <= 0)
        {
            m_gamestatus = GameStatus.GAMEOVER;
        }
        if (Input.GetButtonDown("Pause"))
        {
            if (m_gamestatus == GameStatus.PAUSE)
            {
                m_gamestatus = GameStatus.RESUME;
            }
            else
            {
                m_gamestatus = GameStatus.PAUSE;
            }
        }
        if (m_gamestatus == GameStatus.RESUME || m_gamestatus == GameStatus.START)
        {
            AnimActive();
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
        if (m_gamestatus == GameStatus.PAUSE)
        {
            m_gameStatusText.text = "Pause";
            AnimNonActive();
            if (m_buttons != null)
            {
                foreach (var item in m_buttons)
                {
                    item.SetActive(true);
                }
            }
        }
        //m_timeText.text = string.Format($"{m_minutes:00} : {Mathf.FloorToInt(m_second):00}");

        if (m_gamestatus == GameStatus.GAMEOVER)
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

    public void AnimActive()
    {
        Time.timeScale = 1;
        m.enabled = true;
        Player.Instance.ActionStart();
    }

    public void AnimNonActive()
    {
        Debug.Log("ac");
        Time.timeScale = 0;
        m.enabled = false;
        Player.Instance.ActionStop();
    }

    public GameStatus GetGameStatus()
    {
        return m_gamestatus;
    }

    public void SetGameStatus(GameStatus gameStatus)
    {
        m_gamestatus = gameStatus;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

}
