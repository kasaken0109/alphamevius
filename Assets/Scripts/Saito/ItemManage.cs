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
        {ItemEnum.AluminiumKnife,0 },
        {ItemEnum.FragileKnife,0 },
        {ItemEnum.SmallKnife,0 },
        {ItemEnum.Machete,0 },
        {ItemEnum.Pickaxe1,0 },
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
    private void Start()
    {
        Instance = this;
        //ステータスの設定
        for (int i = 0; i < itemList.Count; i++)
        {
            if (i <= (int)ItemEnum.EndMaterial)
            {
                states[i] = ItemStates.UseItem;
            }
            else if(i <= (int)ItemEnum.AxeCore)
            {
                states[i] = ItemStates.MaterialItem;
            }
            else if (i <= (int)ItemEnum.Hammer)
            {
                states[i] = ItemStates.HaveOne;
            }
            else
            {
                states[i] = ItemStates.EventItem;
            }
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
        }
    }
    public void SetItem(ItemBaseMain item, int playerLevel)
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
            itemList[item.GetItemType()] += playerLevel;
        }
    }

}
