using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FieldIObjectを複数種類のツールで攻撃出来るようにしたクラス
/// </summary>
public class FieldObjectArrayController : MonoBehaviour
{
    public static FieldObjectArrayController Instance { get; private set; }
    [SerializeField] protected ToolType []ObjectType;
    [SerializeField] protected int strengthPoint = 120;
    [SerializeField] protected MaterialType[] DropItems;
    /// <summary> 実行アニメーションのパラメーター名/// </summary>
    [SerializeField] string m_animParameterName;
    /// <summary> オブジェクトがアニメーションをしているかどうか/// </summary>
    bool m_IsAnimating;
    /// <summary> アニメーション後に残るオブジェクト/// </summary>
    [SerializeField] GameObject m_spawn;
    Animator m_animator;
    public bool m_isExisted = true;
    private bool m_CanAttack = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spawn.SetActive(false);
        m_IsAnimating = false;
    }

    private void Update()
    {
        ActiveAnim();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            for (int i = 0; i < ObjectType.Length; i++)
            {
                if (ObjectType[i] == PlayerManager.Instance.EquipmentTool)
                {
                    m_CanAttack = true;
                }
            }
            if (m_CanAttack)
            {
                strengthPoint -= PlayerManager.Instance.EquipmentPower;
                if (strengthPoint <= 0)
                {
                    EffectManager.PlayEffect(EffectType.Smoke1, transform.position);
                    if (DropItems != null)
                    {
                        FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    }
                    FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    m_isExisted = false;
                }
            }
        }
    }

    public void ActiveAnim()
    {
        Debug.Log(m_isExisted);
        ///消えるコライダーのオブジェクト名はPreColliderに統一する
        if (!m_isExisted)
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
