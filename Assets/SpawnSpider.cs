using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpider : MonoBehaviour
{
    [SerializeField] Spider m_spider = null;
    [SerializeField] GameObject gameObject;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Instance.GetDayStatus() == TimeManager.DayStatus.NIGHT)
        {
            gameObject.SetActive(true);
            m_spider.StartSpawn();
        }
    }
}
