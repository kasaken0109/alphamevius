using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    [SerializeField] Spider m_spider = null;
    [SerializeField] GameObject gameObject;
    bool CanSpawn = false;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT && !CanSpawn)
        {
            gameObject.SetActive(true);
            m_spider.StartSpawn();
            CanSpawn = true;
        }
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NOON)
        {
            CanSpawn = false;
        }
    }
}
