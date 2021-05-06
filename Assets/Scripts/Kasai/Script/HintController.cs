using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField] GameObject m_hint = null;
    // Start is called before the first frame update
    void Start()
    {
        m_hint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_hint.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_hint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_hint.SetActive(false);
    }
}
