using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTransformcontroller : MonoBehaviour
{
    RectTransform m_rectTransform = null;
    Camera m_canvas = null;
    // Start is called before the first frame update
    void Start()
    {
        //m_canvas = GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 TextChangeWorldPosition(RectTransform rect)
    {
        //UI座標からスクリーン座標に変換
        //Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(m_canvas.w, rect.position);

        //ワールド座標
        Vector3 result = Vector3.zero;

        //スクリーン座標→ワールド座標に変換
        //RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPos, m_canvas.worldCamera, out result);

        return result;
    }
}
