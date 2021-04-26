using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolItmes", menuName = "ToolItems")]
public class NewToolItem : NewItem
{
    
    [SerializeField] ToolType m_toolType;
    /// <summary>攻撃力</summary>
    [SerializeField] int m_attackPoint;
    /// <summary>道具効率</summary>
    [SerializeField] int m_toolEfficiency;
}
