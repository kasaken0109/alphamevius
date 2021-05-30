using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] AudioClip []m_BGMs = null;
    AudioClip m_bgm;
    AudioSource audioSource;
    NightRemainController m_nightRemain;
    // Start is called before the first frame update
    private void Awake()
    {
        m_nightRemain = GameObject.Find("NightObject").GetComponentInChildren<NightRemainController>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        m_bgm = m_BGMs[0];
        PlayBgm(m_bgm);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_BGMs.Length >= 2)
        {
            if (m_nightRemain.IsRemain)
            {
                m_bgm = m_BGMs[1];
                PlayBgm(m_bgm);
            }
            else
            {
                m_bgm = m_BGMs[0];
                PlayBgm(m_bgm);
            }
            
        }
    }

    /// <summary>
    /// BGM を再生する
    /// </summary>
    public void PlayBgm(AudioClip audioClip)
    {
        audioSource.clip = m_bgm;
        audioSource.loop = true;
        audioSource.Play();
    }

    /// <summary>
    /// BGM を止める
    /// </summary>
    public void StopBgm()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
