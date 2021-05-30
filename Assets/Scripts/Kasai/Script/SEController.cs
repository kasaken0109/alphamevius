using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    [SerializeField] AudioClip m_damage;
    [SerializeField] AudioClip m_attack;
    [SerializeField] AudioClip m_clear;
    [SerializeField] AudioClip m_UI;
    [SerializeField] AudioClip m_getItem;
    [SerializeField] AudioClip[] m_walk;
    AudioSource m_audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
