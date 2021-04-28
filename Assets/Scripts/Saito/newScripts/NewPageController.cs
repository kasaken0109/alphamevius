using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPageController : MonoBehaviour
{
    [SerializeField] GameObject[] m_pages;
    [SerializeField] GameObject m_nextPageBottun;
    [SerializeField] GameObject m_backPageBottun;
    int m_totalPageNum;
    int m_pageNum;
    private void Start()
    {
        ClosePage();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OpenPage(0);
        }
    }
    public void OpenPage(int pageNum)
    {
        m_totalPageNum = pageNum;
        if (m_totalPageNum > 0)
        {
            m_nextPageBottun.SetActive(true);
        }
        else
        {
            m_nextPageBottun.SetActive(false);
        }
        m_pageNum = 0;
        m_backPageBottun.SetActive(false);
        foreach (var item in m_pages)
        {
            item.GetComponent<RectTransform>().localPosition = new Vector2(2000, 2000);
        }
        m_pages[m_pageNum].GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
    public void NextPage()
    {
        m_backPageBottun.SetActive(true);
        m_pages[m_pageNum].GetComponent<RectTransform>().localPosition = new Vector2(2000, 2000);
        m_pageNum++;
        if (m_pageNum >= m_totalPageNum)
        {
            m_pageNum = m_totalPageNum;
            m_nextPageBottun.SetActive(false);
        }        
        m_pages[m_pageNum].GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
    public void BackPage()
    {
        m_nextPageBottun.SetActive(true);
        m_pages[m_pageNum].GetComponent<RectTransform>().localPosition = new Vector2(2000, 2000);
        m_pageNum--;
        if (m_pageNum <= 0)
        {
            m_pageNum = 0;
            m_backPageBottun.SetActive(false);
        }
        m_pages[m_pageNum].GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
    public void ClosePage()
    {
        foreach (var item in m_pages)
        {
            item.GetComponent<RectTransform>().localPosition = new Vector2(2000, 2000);
        }
        m_nextPageBottun.SetActive(false);
        m_backPageBottun.SetActive(false);
    }
}
