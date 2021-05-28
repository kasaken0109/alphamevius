using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightObjectManager : MonoBehaviour
{
    [SerializeField] GameObject m_obj = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT)
        {
            m_obj.SetActive(true);
        }
        else
        {
            m_obj.SetActive(false);
        }
    }
}
