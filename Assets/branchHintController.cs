using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchHintController : MonoBehaviour
{
    public static branchHintController Instance { get; private set; }
    [SerializeField] GameObject m_hint = null; 
    // Start is called before the first frame update
    void Start()
    {
        m_hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HintActive()
    {
        m_hint.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HintActive();
        }  
    }
}
