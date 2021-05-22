using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBagController : MonoBehaviour
{
    //TimeManager time;
    [SerializeField] int nightTime = 18;
    [SerializeField] int morningTime = 6;
    [SerializeField] ActionRange actionRange = null;
    [SerializeField] GameObject m_Button = null;
    [SerializeField] GameObject m_animSleepBag = null;
    [SerializeField] GameObject m_SleepBag = null;
    //[SerializeField] Transform m_player = null;
    // Start is called before the first frame update
    void Start()
    {
        //time = GetComponent<TimeManager>();
        m_Button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(actionRange.ONPlayer());
        if (actionRange.ONPlayer())
        {
            m_Button.SetActive(true);
        }
        else
        {
            m_Button.SetActive(false);
        }
    }
    public void UseSleepBag()
    {
        if (TimeManager.Instance.m_hour >= nightTime && TimeManager.Instance.m_hour <= 24)
        {
            Debug.Log("nightleap");
            m_SleepBag.SetActive(false);
            Instantiate(m_animSleepBag, transform.position, transform.rotation);
            TimeManager.Instance.m_dayNum += 1;
            TimeManager.Instance.m_hour = morningTime;

        }
        else if (TimeManager.Instance.m_hour >= 0 && TimeManager.Instance.m_hour <= morningTime)
        {
            Debug.Log("morningleap");
            m_SleepBag.SetActive(false);
            Instantiate(m_animSleepBag, transform.position, transform.rotation);
            TimeManager.Instance.m_hour = morningTime;
        }
        else
        {
            Debug.Log("寝袋は今使えません");
        }
    }
}
