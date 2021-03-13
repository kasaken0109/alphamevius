using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    public static ItemManage Instance { get; private set; }
    #region アイテムごとに必要なクラフト素材
    public List<ItemEnum> AluminiumKnifeCraft = new List<ItemEnum> { ItemEnum.AluminumCan, ItemEnum.PieceOfCloth };
    public List<ItemEnum> FragileKnifeCraft = new List<ItemEnum> { ItemEnum.BrokenBottle, ItemEnum.Aluminium };
    public List<ItemEnum> SmallKnifeCraft = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> MacheteCraft = new List<ItemEnum> { ItemEnum.KnifeCore, ItemEnum.FragmentOfOre, ItemEnum.Wood };
    public List<ItemEnum> Pickaxe1Craft = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> Pickaxe2Craft = new List<ItemEnum> { ItemEnum.PickaxeCore, ItemEnum.BearClaws,ItemEnum.DurableBranches };
    public List<ItemEnum> TrapCraft = new List<ItemEnum> { ItemEnum.Straw, ItemEnum.SuppleBranches };
    public List<ItemEnum> AxeCraft = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> HammerCraft = new List<ItemEnum> { ItemEnum.AxeCore, ItemEnum.HardOre };
    public List<ItemEnum> BridgeCraft = new List<ItemEnum> { ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy };
    public List<ItemEnum> FireCraft = new List<ItemEnum> { ItemEnum.DeadBranch, ItemEnum.Straw };
    #endregion

    #region アイテムを分解すると手に入る素材
    public ItemEnum amallKnefeDisassembly = ItemEnum.KnifeCore;
    public ItemEnum pickaxe1Disassembly = ItemEnum.PickaxeCore;
    public ItemEnum aluminiumKnifeDisassembly = ItemEnum.Aluminium;
    public ItemEnum fragileKnifeDisassembly = ItemEnum.IronPiece;
    public ItemEnum axeDisassembly = ItemEnum.AxeCore;
    #endregion

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
    private void Start()
    {
        Instance = this;

    }
    public void GetItem(ItemBaseMain item)
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
    public void GetItem(ItemBaseMain item, int playerLevel)
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
