using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]ActionRange actionRange;
    [SerializeField] GameObject m_message;
    private void Start()
    {
        m_message.SetActive(false);
    }
    void Update()
    {
        if (actionRange.ONPlayer())
        {
            m_message.SetActive(true);
            SoundManager.Instance.PlayFire();
        }
        else
        {
            m_message.SetActive(false);
            SoundManager.Instance.StopFire();
        }
    }
    public void OnClickCooking()
    {
        ZInventoryManager.Instance.OnClickOpenCooking();
    }

    public void CloseGuide()
    {
        m_message.SetActive(false);
    }
}
