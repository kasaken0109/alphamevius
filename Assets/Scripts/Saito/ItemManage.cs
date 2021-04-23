using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManage : MonoBehaviour
{
    public static ItemManage Instance { get; private set; }
    public int m_ricyclePoints = 0;
    public int m_playerLevel = 1;
    public int m_playerExp = 0;
    /// <summary>
    /// 装備中のアイテム
    /// </summary>
    public HaveItem m_equipment;
    public Text m_equipmentText;
    public Slider m_equipmentDurable;
    public Dictionary<ItemEnum, int> itemList = new Dictionary<ItemEnum, int>()
    {
        #region ディクショナリーの初期化
        {ItemEnum.Chicken,0 },
        {ItemEnum.Venison,0 },
        {ItemEnum.BakedChicken,0 },
        {ItemEnum.Jibie,0 },
        {ItemEnum.WaterBottle,0 },
        {ItemEnum.Herbs,0 },
        {ItemEnum.HealingDrug,0 },
        {ItemEnum.EndMaterial,0 },
        {ItemEnum.PetBottles,0 },
        {ItemEnum.BrokenBottle,0 },
        {ItemEnum.AluminumCan,0 },
        {ItemEnum.PieceOfCloth,0 },
        {ItemEnum.Stone,0 },
        {ItemEnum.DeadBranch,0 },
        {ItemEnum.Straw,0 },
        {ItemEnum.SuppleBranches,0 },
        {ItemEnum.DurableBranches,0 },
        {ItemEnum.IronPiece,0 },
        {ItemEnum.BearClaws,0 },
        {ItemEnum.FragmentOfOre,0 },
        {ItemEnum.HardOre,0 },
        {ItemEnum.DurableIvy,0 },
        {ItemEnum.Wood,0 },
        {ItemEnum.Aluminium,0 },
        {ItemEnum.KnifeCore,0 },
        {ItemEnum.PickaxeCore,0 },
        {ItemEnum.AxeCore,0 },
        {ItemEnum.Glass,0 },
        {ItemEnum.AluminiumKnife,0 },
        {ItemEnum.FragileKnife,0 },
        {ItemEnum.SmallKnife,0 },
        {ItemEnum.Machete,0 },
        {ItemEnum.GlassPickaxe,0 },
        {ItemEnum.Pickaxe2,0 },
        {ItemEnum.Trap,0 },
        {ItemEnum.Axe,0 },
        {ItemEnum.Hammer,0 },
        {ItemEnum.Bridge,0 },
        {ItemEnum.Fire,0 }
        #endregion
    };
    public ItemStates[] states;
    public Text[] itemText;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (m_equipment)
        {
            m_equipmentDurable.value = HaveItemManager.Instance.GetItemCurrentHP(m_equipment.GetID()) / HaveItemManager.Instance.GetItemMaxHP(m_equipment.GetID());
        }
    }
    public void SetItem(ItemBaseMain item)
    {
        if(item.CheckHaveOne())
        {
            if (itemList[item.GetItemType()] == 0)
            {
                Debug.Log("入手");
                itemList[item.GetItemType()]++;
            }
            Debug.Log("複数入手することは出来ません");
        }
        else
        {
            Debug.Log("入手");
            itemList[item.GetItemType()]++;
            //HotBarManager.Instance.ChangeHotBarText();
        }
    }
    public void SetItem(ItemBaseMain item, int addNum)
    {
        if (item.CheckHaveOne())
        {
            if (itemList[item.GetItemType()] == 0)
            {
                Debug.Log("入手");
                itemList[item.GetItemType()]++;
            }
            Debug.Log("複数入手することは出来ません");
        }
        else
        {
            Debug.Log("入手");
            itemList[item.GetItemType()] += addNum;
            //HotBarManager.Instance.ChangeHotBarText();
        }
    }
    /// <summary>
    /// アイテムを所持してるか確認し、所持していたら所持数を1減らしつつtrueを返す
    /// </summary>
    /// <param name="type">使うアイテムのタイプ</param>
    /// <returns>使ったかどうか</returns>
    public bool UseItem(ItemEnum type)
    {
        if (itemList[type] > 0)
        {
            itemList[type]--;
            Debug.Log("使った");
            //HotBarManager.Instance.ChangeHotBarText();
            return true;
        }
        else
        {
            Debug.Log("持ってない");
            return false;
        }
    }
    public void EquipItem(ItemBaseMain item)
    {
        if (states[(int)item.GetItemType()] == ItemStates.HaveItem)
        {
            Debug.Log("装備した");
            m_equipment = (HaveItem)item;
            m_equipmentText.text = m_equipment.GetItemType().ToString();
            //PlayerManager.Instance.SetPower(m_equipment.GetAttack());
        }
        else
        {
            Debug.Log("装備品ではありません");
        }
    }
    /// <summary>
    /// 装備してるアイテムを返す
    /// </summary>
    /// <returns></returns>
    public ItemEnum GetEquipment()
    {
        return m_equipment.GetItemType();
    }
    /// <summary>
    /// 装備してるアイテムのIDを返す
    /// </summary>
    /// <returns></returns>
    public int GetEquipmentID()
    {
        return m_equipment.GetID();
    }
}
