using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolItmes", menuName = "ToolItems")]
public class NewToolItem : NewItem
{    
    [SerializeField] ToolType m_toolType;
    /// <summary>攻撃力</summary>
    [SerializeField] int m_attackPoint = 0;
    /// <summary>道具効率</summary>
    [SerializeField] int m_toolEfficiency = 0;
    /// <summary>必要レベル,初期値0</summary>
    [SerializeField] int m_craftLevel = 0;    
    public override ToolType GetToolType()
    {
        return m_toolType;
    }
    public override int GetAttackPoint() { return m_attackPoint; }
    public override int GetEfficiency() { return m_toolEfficiency; }
    public override int GetCraftLevel() { return m_craftLevel; }
}
