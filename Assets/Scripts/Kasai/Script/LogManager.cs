using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public static  LogManager Instance { get; private set; }
    List <LogController>logList;
    [SerializeField] GameObject log = null;
    private int m_maxNum = 3;
    int index = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        logList = new List<LogController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLog(string text, int num)
    {
        GameObject m_logs = Instantiate(log);
        m_logs.transform.SetParent(this.gameObject.transform);
        LogController logs = m_logs.GetComponent<LogController>();
        logList.Add(logs);
        index++;
        if (index > m_maxNum)
        {
            logList.Remove(logList[0]);
            Destroy(logList[0]);
            index = 1;
        }
        logList[index - 1].DisplayLog(text + " * " + num);
    }
}
