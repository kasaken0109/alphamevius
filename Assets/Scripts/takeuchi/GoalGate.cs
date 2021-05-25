using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGate : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_gates;
    [SerializeField] float m_clearColorSpeed = 1f;
    [SerializeField] GameObject m_gateObject;
    bool m_goalF;
    public void OpenGoalGate()
    {
        if (m_goalF)
        {
            return;
        }
        StartCoroutine(OpenGate());
        MessgaeManager.ViweMessage("遺跡の封印が解かれた");
    }
    private IEnumerator OpenGate()
    {
        m_goalF = true;
        float clearScale = 1f;
        while (clearScale > 0)
        {
            clearScale -= m_clearColorSpeed * Time.deltaTime;
            if (clearScale < 0)
            {
                clearScale = 0;
            }
            foreach (var gate in m_gates)
            {
                gate.color = new Color(1, 1, 1, clearScale);
            }
            yield return new WaitForEndOfFrame();
        }
        m_gateObject.SetActive(false);
    }
}
