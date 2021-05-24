using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorControl : MonoBehaviour
{
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;
    void Update()
    {
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        gameObject.transform.position = screenToWorldPointPosition;
    }
}
