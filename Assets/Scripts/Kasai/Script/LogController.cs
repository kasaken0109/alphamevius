using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LogController : MonoBehaviour
{
    [SerializeField]GameObject m_textObject = null;
    Text m_text = null;
    [SerializeField] Color color;
    // Start is called before the first frame update
    void Start()
    {
        m_text = m_textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLog(string text)
    {
        m_text.text = text;
        m_text.DOColor(color, 2);
    }

    //public void 

    //public void FadeText(Text text)
    //{
    //    text.DOColor(color, 2);
    //}
}
