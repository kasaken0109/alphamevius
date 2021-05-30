using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlace : MonoBehaviour
{
    [SerializeField] GameObject m_guide = null;
    [SerializeField] ActionRange actionRange = null;
    [SerializeField] float m_normalHintSize = 0.0025f;
    private bool IsFirstTime = true;

    private void Update()
    {
        if (actionRange.ONPlayer())
        {
            //Debug.Log("Rangetrue");
            m_guide.SetActive(true);
        }
        else
        {
            //Debug.Log("Rangefalse");
            m_guide.SetActive(false);
        }
        if (IsFirstTime == false)
        {
            m_guide.gameObject.transform.localScale = new Vector3(m_normalHintSize,m_normalHintSize,1);
            //m_guide.transform.localScale
        }
    }
    
    public void Drink()
    {
        if (PlayerManager.Instance.CurrentHydrate <= 90)
        {
            MessgaeManager.ViweMessage("冷くおいしい水だった");
            PlayerManager.Instance.HealingHydrate(100);
            m_guide.SetActive(false);
            IsFirstTime = false;
        }
        else
        {
            MessgaeManager.ViweMessage("今はのどは乾いていない");
        }
    }
}
