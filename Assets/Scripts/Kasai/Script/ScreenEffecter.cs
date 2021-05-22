using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffecter : MonoBehaviour
{
    public static ScreenEffecter Instance { get; private set;}
    [SerializeField] private Image m_image = null;
    [SerializeField] private int m_fadeSpeed = 1;
    Color m_panelColor;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        if (m_panelColor.a > 0.01f)
        {
            m_panelColor.a -= 0.01f * m_fadeSpeed;
            m_image.color = m_panelColor;
        }
    }
    public void FadeOut()
    {
        if (m_panelColor.a <= 0.99f)
        {
            m_panelColor.a += 0.01f * m_fadeSpeed;
            m_image.color = m_panelColor;
        }
    }
}
