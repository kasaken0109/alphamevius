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
    bool m_IsAnimating;
    /// <summary> アニメーション後に残るオブジェクト/// </summary>
    [SerializeField] GameObject m_spawn;
    [SerializeField] FieldObjectArrayController m_arrayController = null;
    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_arrayController = GetComponent<FieldObjectArrayController>();
        m_spawn.SetActive(false);
        m_IsAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void ActiveAnim()
    {
        Debug.Log(m_arrayController.m_isExisted);
        ///消えるコライダーのオブジェクト名はPreColliderに統一する
        if (!m_arrayController.m_isExisted)
        {
            Debug.Log("Notfound");
            m_IsAnimating = true;
            if (m_animParameterName != null)
            {
                m_animator.SetBool(m_animParameterName, m_IsAnimating);
                m_IsAnimating = false;
                StartCoroutine("Animation");
            }
        }
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(1);
        m_spawn.SetActive(true);
        gameObject.SetActive(false);
        yield return null;
    }
}
