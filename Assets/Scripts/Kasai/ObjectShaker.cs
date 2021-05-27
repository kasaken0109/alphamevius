using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShaker : MonoBehaviour
{
    public static ObjectShaker Instance{get;private set;}
    [SerializeField] private float m_shakeXpos = 0.3f;
    [SerializeField] private float m_shakeYpos = 0.3f;
    [SerializeField] private float m_shakeTime = 0.5f;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public void ShakeScreen()
    {
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", m_shakeXpos,"y", m_shakeYpos,"time",m_shakeTime));
    }

    public void ShakeObject(GameObject shakeObj)
    {
        iTween.ShakePosition(shakeObj, iTween.Hash("x", m_shakeXpos, "y", m_shakeYpos, "time", m_shakeTime));
    }

    public void ShakeObject(GameObject shakeObj ,float shakeXpos, float shakeYpos ,float shakeTime)
    {
        iTween.ShakePosition(shakeObj, iTween.Hash("x", shakeXpos, "y", shakeYpos, "time", shakeTime));
    }
}
