using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffecter : MonoBehaviour
{
    public static ScreenEffecter Instance { get; private set;}
    [SerializeField] Animator m_image = null;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        m_image = GetComponent<Animator>();
        
    }

    private void Start()
    {
        m_image = GetComponent<Animator>();
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FadeIn()
    {
        Debug.Log("FadeIn");
        m_image.Play("FadeIn");  
    }
    public void FadeOut()
    {
        //m_image.Play("FadeOut");
    }
}
