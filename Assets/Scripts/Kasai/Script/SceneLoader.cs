using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>ロードするシーン名</summary>
    [SerializeField] public string m_sceneNameToBeLoaded = "SceneNameToBeLoaded";
    /// <summary>フェードするためのマスクとなる Panel (Image) を指定する。アルファを 0 にしておき、必要ならば Raycast Target をオフにしておくこと。</summary>
    [SerializeField] Image m_fadePanel = null;
    /// <summary>フェードするスピード</summary>
    [SerializeField] float m_fadeSpeed = 1f;
    /// <summary>ロード開始フラグ</summary>
    bool m_isLoadStarted = false;
    public ScreenEffecter screenEffecter;
    bool IsEndAnim = false;

    void Update()
    {
        // ロードが開始されたら
        //if (m_isLoadStarted)
        //{
        //    // m_panel が設定されていたら、徐々にアルファを上げて不透明にする
        //    if (m_fadePanel)
        //    {
        //        Color panelColor = m_fadePanel.color;
        //        panelColor.a += m_fadeSpeed * Time.deltaTime;
        //        m_fadePanel.color = panelColor;

        //        // ほぼ不透明になったら
        //        if (panelColor.a > 0.99f)
        //        {
        //            // シーンをロードする
        //            SceneManager.LoadScene(m_sceneNameToBeLoaded);
        //            m_isLoadStarted = false;
        //        }
        //    }
        //    else
        //    {
        //        // m_panel が設定されていない時は、すぐにシーンをロードする

        //        SceneManager.LoadScene(m_sceneNameToBeLoaded);
        //        m_isLoadStarted = false;
        //    }
        //}
        if (m_isLoadStarted)
        {
            StartCoroutine("SceneLoad");
            screenEffecter.FadeOut();
        }
    }


    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(m_sceneNameToBeLoaded);
        m_isLoadStarted = false;
        yield return null;

    }
    /// <summary>
    /// シーンをロードする
    /// </summary>
    public void LoadScene()
    {
        Debug.Log("LoadStart");
        m_isLoadStarted = true;
        Debug.Log("LoadEnd");
    }

    /// <summary>
    /// 名前を指定してシーンをロードする
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        m_isLoadStarted = true;
        m_sceneNameToBeLoaded = sceneName;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndAnim()
    {
        IsEndAnim = true;
    }
}
