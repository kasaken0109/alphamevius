using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioClip m_bgm;
    [SerializeField] AudioClip m_hit;
    [SerializeField] AudioClip m_damage;
    [SerializeField] AudioClip m_clear;
    AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    } 
    /// <summary>
    /// BGM を再生する
    /// </summary>
    public void PlayBgm()
    {
        m_audioSource.clip = m_bgm;
        m_audioSource.loop = true;
        m_audioSource.Play();
    }

    /// <summary>
    /// BGM を止める
    /// </summary>
    public void StopBgm()
    {
        if (m_audioSource.isPlaying)
        {
            m_audioSource.Stop();
        }
    }

    /// <summary>
    /// プレイヤー被ダメージ時の SE を鳴らす
    /// </summary>
    public void PlaySeGetDamage()
    {
        m_audioSource.PlayOneShot(m_damage);
    }

    /// <summary>
    /// ステージクリア時の SE を鳴らす
    /// </summary>
    public void PlaySeClear()
    {
        m_audioSource.PlayOneShot(m_clear);
    }
}
