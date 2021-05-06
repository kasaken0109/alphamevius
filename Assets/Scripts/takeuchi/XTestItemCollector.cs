using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XTestItemCollector : MonoBehaviour
{
    public static XTestItemCollector Instanse { get; private set; }
    int point = 0;
    [SerializeField] Text scoreText;
    private void Awake()
    {
        Instanse = this;
    }
    public void ItemGet()
    {
        point++;
        scoreText.text = point.ToString() + "点";
        if (point >= 20)
        {
            scoreText.text = "クリア";
        }
    }
}
