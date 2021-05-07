using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フィールドオブジェクトのアニメーションを操作する
/// </summary>
public class ObjectAnimationController : MonoBehaviour
{
    /// <summary> 消えるオブジェクトのコライダー/// </summary>
    [SerializeField] string m_objectColliderName = "PreCollider";
    /// <summary> 実行アニメーションのパラメーター名/// </summary>
    [SerializeField] string m_animParameterName;
    /// <summary> オブジェクトがアニメーションをしているかどうか/// </summary>
    [SerializeField] bool m_IsAnimating;
    /// <summary> アニメーション後に残るオブジェクト/// </summary>
    [SerializeField] GameObject m_spawn;
    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spawn.SetActive(false);
        m_IsAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveAnim();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void ActiveAnim()
    {
        ///消えるコライダーのオブジェクト名はPreColliderに統一する
        if (GameObject.Find(m_objectColliderName))
        {
            m_IsAnimating = true;
        }
        if (m_animParameterName != null)
        {
            m_animator.SetBool(m_animParameterName, m_IsAnimating);
        }
        m_IsAnimating = false;
        StartCoroutine("Animation");
        Destroy(this.gameObject ,1);
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(1);
        m_spawn.SetActive(true);
    }
}
