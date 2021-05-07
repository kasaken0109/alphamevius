using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTarget : MonoBehaviour
{
    private void OnMouseDown()
    {
        Vector2 dir = transform.position - Player.Instance.transform.position;
        Player.Instance.ArrowShot(dir);
    }
}
