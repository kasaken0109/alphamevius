using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    [SerializeField] Image thisImage;
    [SerializeField] float blinkingSpan = 0.1f;
    [SerializeField] float blinkingSpeed = 1f;
    float clearScale;
    float R;
    float G;
    float B;
    bool clear = false;
    private void Start()
    {
        clearScale = blinkingSpan;
        R = thisImage.color.r;
        G = thisImage.color.g;
        B = thisImage.color.b;
    }
    void Update()
    {
        int x = 1;
        if (clear)
        {
            x = -1;
        }
        clearScale += x * blinkingSpeed * Time.deltaTime;
        if (clearScale >= 1)
        {
            clearScale = 1;
            clear = true;
        }
        else if (clearScale <= blinkingSpan)
        {
            clearScale = blinkingSpan;
            clear = false;
        }
        thisImage.color = new Color(R, G, B, clearScale);
    }
}
