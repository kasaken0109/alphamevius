using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBagManager : MonoBehaviour
{
    public static SleepBagManager Instance { get; private set;}
    TimeManager time;
    [SerializeField] int nightTime = 20;
    [SerializeField] int morningTime = 6;
    [SerializeField] ActionRange actionRange = null;
    [SerializeField] GameObject m_Button = null;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        time = GetComponent<TimeManager>();
    }
    void Start()
    {
        m_Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(actionRange.ONPlayer());
        if (actionRange.ONPlayer())
        {
            m_Button.SetActive(true);
        }
    }
    /// <summary>
    /// 寝袋を設置するときに呼ばれる関数
    /// </summary>
    /// <param name="m_player">プレイヤーの位置</param>
    public void CreateSleepBag(Transform m_player)
    {
        Instantiate(this.gameObject, m_player.position, m_player.rotation);
    }
    
    public void UseSleepBag()
    {
        if (TimeManager.Instance.m_hour >= nightTime && TimeManager.Instance.m_hour <= 24)
        {
            Debug.Log("nightleap");
            TimeManager.Instance.m_dayNum += 1;
            TimeManager.Instance.m_hour = morningTime;

        }
        else if (TimeManager.Instance.m_hour >= 0 && TimeManager.Instance.m_hour <= morningTime)
        {
            Debug.Log("morningleap");
            TimeManager.Instance.m_hour = morningTime;
        }
        else
        {
            Debug.Log("寝袋は今使えません");
        }
    }
}
