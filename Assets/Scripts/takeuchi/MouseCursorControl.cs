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
    //private void OnMouseDown()
    //{
    //    Vector2 dir = transform.position - Player.Instance.transform.position;
    //    //Player.Instance.ArrowShot(dir);
    //    Debug.Log("test!");
    //}
    public void OnClick()
    {
        //Debug.Log("mouseClick");
        Vector2 dir = transform.position - Player.Instance.transform.position;
        Player.Instance.AttackAction(dir);
    }
}
