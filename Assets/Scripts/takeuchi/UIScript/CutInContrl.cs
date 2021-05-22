using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutInContrl : MonoBehaviour
{
    [SerializeField] Image[] m_cutInImage;
    [SerializeField] float m_cutInTime = 2f;
    [SerializeField] float m_clearSpeed = 1f;
    float m_clearScale = 0f;
    float m_cutInTimer = 0f;

    void Start()
    {
        foreach (var item in m_cutInImage)
        {
            item.color = Color.clear;
        }
    }
    public void PlayCutIn(int number)
    {
        StartCoroutine(CutInStart(number));
    }
    private IEnumerator CutInStart(int number)
    {
        m_clearScale = 0;
        while (m_clearScale < 1)
        {
            m_clearScale += m_clearSpeed * Time.deltaTime;
            if (m_clearScale > 1)
            {
                m_clearScale = 1;
            }
            m_cutInImage[number].color = new Color(1, 1, 1, m_clearScale);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(CutInViwe(number));
    }
    private IEnumerator CutInViwe(int number)
    {
        m_cutInTimer = m_cutInTime;
        while (m_cutInTimer > 0)
        {
            m_cutInTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(CutInEnd(number));
    }
    private IEnumerator CutInEnd(int number)
    {
        m_clearScale = 1;
        while (m_clearScale > 0)
        {
            m_clearScale -= m_clearSpeed * Time.deltaTime;
            if (m_clearScale < 0)
            {
                m_clearScale = 0;
            }
            m_cutInImage[number].color = new Color(1, 1, 1, m_clearScale);
            yield return new WaitForEndOfFrame();
        }
    }
}
