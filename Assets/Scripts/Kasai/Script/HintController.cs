using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField] GameObject m_hint = null;
    Animation m_highlights = null;
    [SerializeField] bool m_hintMode = true;
    // Start is called before the first frame update
    void Start()
    {
        if (m_hintMode)
        {
            m_hint.SetActive(false);
        }
        else
        {
            m_highlights = GetComponent<Animation>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (m_hintMode)
            {
                m_hint.SetActive(true);
            }
            else
            {
                m_highlights.Play();
                Debug.Log("AnimPlay");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (m_hintMode)
            {
                m_hint.SetActive(true);
            }
            else
            {
                m_highlights.Play();
                Debug.Log("AnimPlay");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_hintMode)
        {
            m_hint.SetActive(false);
        } 
    }
}
