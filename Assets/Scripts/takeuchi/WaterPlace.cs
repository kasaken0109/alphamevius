using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlace : MonoBehaviour
{
    [SerializeField] GameObject m_guide = null;
    [SerializeField] ActionRange actionRange = null;
    [SerializeField] float m_normalHintSize = 0.5f;
    private bool IsFirstTime = true;

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
        if (IsFirstTime == true)
        {
            m_guide.gameObject.transform.localScale *= m_normalHintSize;
        }
    }
    
    public void Drink()
    {
        PlayerManager.Instance.HealingHydrate(100);
        IsFirstTime = false;
    }
}
