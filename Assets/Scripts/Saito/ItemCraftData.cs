using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftData : MonoBehaviour
{
    public List<ItemEnum> aluminiumKnife = new List<ItemEnum> { ItemEnum.AluminumCan, ItemEnum.PieceOfCloth };
    public List<ItemEnum> fragileKnife = new List<ItemEnum> { ItemEnum.BrokenBottle, ItemEnum.Aluminium };
    public List<ItemEnum> smallKnife = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> machete = new List<ItemEnum> { ItemEnum.KnifeCore, ItemEnum.FragmentOfOre, ItemEnum.Wood };
    public List<ItemEnum> pickaxe1 = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> pickaxe2 = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> trap = new List<ItemEnum> { ItemEnum.Straw, ItemEnum.SuppleBranches };
    public List<ItemEnum> axe = new List<ItemEnum> { ItemEnum.IronPiece, ItemEnum.DurableBranches };
    public List<ItemEnum> hammer = new List<ItemEnum> { ItemEnum.AxeCore, ItemEnum.HardOre };
    public List<ItemEnum> bridge = new List<ItemEnum> { ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.Wood, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy, ItemEnum.DurableIvy };
    public List<ItemEnum> fire = new List<ItemEnum> { ItemEnum.DeadBranch, ItemEnum.Straw };

}
