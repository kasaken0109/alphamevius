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
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CreateSleepBag(Transform m_player)
    {
        Instantiate(this.gameObject, m_player.position, m_player.rotation);
    }
    /// <summary>
    /// 寝袋を設置するときに呼ばれる関数
    /// </summary>
    /// <param name="m_player">プレイヤーの位置</param>
    public void UseSleepBag()
    {
        if (actionRange.ONPlayer())
        {

            if (time.m_hour >= nightTime && time.m_hour <= 24)
            {
                time.m_dayNum += 1;
                time.m_hour = morningTime;

            }
            else if (time.m_hour >= 0 && time.m_hour <= morningTime)
            {
                time.m_hour = morningTime;
            }
            else
            {
                Debug.Log("寝袋は今使えません");
            }
        }
    }
}
