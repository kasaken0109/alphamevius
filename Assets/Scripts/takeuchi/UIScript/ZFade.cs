using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZFade : MonoBehaviour
{
    [SerializeField] Image m_fadePanel;
    public bool FadeNow { get; private set; }
    public bool FadeInEnd { get; private set; }
    public bool FadeOutEnd { get; private set; }
    private float clearScale;
    private float speed = 0.7f;
    public void StartFadeIn()
    {
        if (FadeNow)
        {
            Debug.Log("フェード中");
            return;
        }
        StartCoroutine(FadeIn());
    }
    public void StartFadeOut()
    {
        if (FadeNow)
        {
            Debug.Log("フェード中");
            return;
        }
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        FadeNow = true;
        clearScale = 0;
        while (!FadeOutEnd)
        {
            clearScale += Time.deltaTime;
            if (clearScale >= 1f)
            {
                clearScale = 1;
                FadeOutEnd = true;
                FadeInEnd = false;
            }
            m_fadePanel.color = new Color(0, 0, 0, clearScale);
            yield return new WaitForEndOfFrame();
        }
        FadeNow = false;
    }
    private IEnumerator FadeIn()
    {
        FadeNow = true;
        clearScale = 1;
        while (!FadeInEnd)
        {
            clearScale -= Time.deltaTime;
            if (clearScale <= 0f)
            {
                clearScale = 0;
                FadeInEnd = true;
                FadeOutEnd = false;
            }
            m_fadePanel.color = new Color(0, 0, 0, clearScale);
            yield return new WaitForEndOfFrame();
        }
        FadeNow = false;
    }
    public void FadeControlEnd()
    {
        FadeInEnd = false;
        FadeOutEnd = false;
    }
}
