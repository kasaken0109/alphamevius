using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}
    [SerializeField] AudioClip m_bgm;
    [SerializeField] AudioClip m_damage;
    [SerializeField] AudioClip m_attack;
    [SerializeField] AudioClip m_clear;
    [SerializeField] AudioClip m_UI;
    [SerializeField] AudioClip m_getItem;
    [SerializeField] AudioClip []m_walk;
    [SerializeField] AudioClip m_fire;
    AudioSource m_audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        Instance = this;
    }
    void Start()
    {
        
        //PlayBgm(m_bgm);
    }

    private void Update()
    {
    }
    /// <summary>
    /// BGM を再生する
    /// </summary>
    public void PlayBgm(AudioClip audioClip)
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
    /// BGM を再生する
    /// </summary>
    public void PlayFire()
    {
        m_audioSource.clip = m_fire;
        m_audioSource.loop = true;
        m_audioSource.Play();
    }

    /// <summary>
    /// BGM を止める
    /// </summary>
    public void StopFire()
    {
        if (m_audioSource.isPlaying)
        {
            m_audioSource.Stop();
        }
    }


    /// <summary>
    /// 攻撃時の SE を鳴らす
    /// </summary>
    public void PlayAttack()
    {
        m_audioSource.PlayOneShot(m_attack);
        Debug.Log("ATTTack");
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

    /// <summary>
    /// UI操作時の SE を鳴らす
    /// </summary>
    public void PlayUISound()
    {
        m_audioSource.PlayOneShot(m_UI);
    }

    /// <summary>
    /// アイテム取得時の SE を鳴らす
    /// </summary>
    public void PlayGetItem()
    {
        //Debug.Log("PlayGetItem");
        m_audioSource.PlayOneShot(m_getItem, 1);
    }

    /// <summary>
    /// アイテム取得時の SE を鳴らす
    /// </summary>
    public void PlayWalk()
    {
        m_audioSource.PlayOneShot(m_walk[0]);
        Debug.Log("walkSound");
    }

}
