using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]ActionRange actionRange;
    [SerializeField] GameObject m_message = null;
    [SerializeField] UIManager UIManager = null;
    void Start()
    {
        //m_message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (actionRange.ONPlayer())
        //{
        //    m_message.SetActive(true);
        //}
        //else
        //{
        //    m_message.SetActive(false);
        //}
    }
}
