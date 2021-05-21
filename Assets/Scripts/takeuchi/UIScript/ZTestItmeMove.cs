using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZTestItmeMove : MonoBehaviour
{
    [SerializeField] Image m_image;
    [SerializeField] RectTransform m_pos;
    [SerializeField] float m_flightTime = 1;
    [SerializeField] float m_speedRate = 1;
    private const float m_gravity = -9.8f;
    public bool Move { get; private set; }

    void Start()
    {
        m_pos.localPosition = new Vector2(2000, 2000);
    }
    public void ItemGetMove(Sprite sprite,Vector2 startPos, Vector2 endPos) 
    {
        Move = true;
        m_pos.localPosition = startPos - new Vector2(700, 500);
        m_image.sprite = sprite;
        StartCoroutine(Jump(endPos - new Vector2(600, 350), m_flightTime, m_speedRate, m_gravity));
    }
    private IEnumerator Jump(Vector2 endPos, float flightTime, float speedRate, float gravity)
    {
        Vector2 startPos = m_pos.localPosition;
        var diffY = (endPos - startPos).y;
        var vn = (diffY - gravity * 0.5f * flightTime * flightTime) / flightTime;
        // 放物運動
        for (var t = 0f; t < flightTime; t += (Time.deltaTime * speedRate))
        {
            var p = Vector2.Lerp(startPos, endPos, t / flightTime); 
            p.y = startPos.y + vn * t + 0.5f * gravity * t * t;
            m_pos.localPosition = p;
            yield return null;
        }
        Move = false;
        m_pos.localPosition = new Vector2(2000, 2000);
    }
}
