using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FieldIObjectを複数種類のツールで攻撃出来るようにしたクラス
/// </summary>
public class FieldObjectArrayController : MonoBehaviour
{
    [SerializeField] protected ToolType []ObjectType;
    [SerializeField] protected int strengthPoint = 120;
    [SerializeField] protected MaterialType[] DropItems;
    private bool m_CanAttack = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
            EffectManager.PlayEffect(EffectType.Hit, transform.position);
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
                    FieldItemManager.Instance.DropMaterial(DropItems, transform.position);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
