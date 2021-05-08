using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessgaeManager : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] float viweTime = 3f;
    float viweTimer;
    static MessgaeManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (viweTimer <= 0)
        {
            return;
        }
        viweTimer -= Time.deltaTime;
        if (viweTimer <= 0)
        {
            messageText.text = "";
        }
    }
    public static void ViweMessgae(string viweText)
    {
        instance.messageText.text = viweText;
        instance.viweTimer = instance.viweTime;
    }
}
