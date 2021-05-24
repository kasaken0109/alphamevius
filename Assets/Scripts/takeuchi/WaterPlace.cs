using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlace : MonoBehaviour
{
    [SerializeField] GameObject m_guide = null;
    [SerializeField] ActionRange actionRange = null;

    private void Update()
    {
        if (actionRange.ONPlayer())
        {
            m_guide.SetActive(true);
        }
        else
        {
            m_guide.SetActive(false);
        }
    }
    
    public void Drink()
    {
        PlayerManager.Instance.HealingHydrate(100);
    }
}
