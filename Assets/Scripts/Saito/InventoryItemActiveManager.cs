using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryItemActiveManager : MonoBehaviour
{
    ItemEnum m_itemEnum;
    Transform[] m_buttons = new Transform[Enum.GetNames(typeof(ItemEnum)).Length];
    private void Start()
    {
        for (int i = 0; i < m_buttons.Length; i++)
        {
            m_buttons[i] = transform.Find("Button (" + i + ")");
        }
    }
    void Update()
    {
        if (ItemManage.Instance.itemList[ItemEnum.Chicken] <= 0)
        {
            m_buttons[(int)ItemEnum.Chicken].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Chicken].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Venison] <= 0)
        {
            m_buttons[(int)ItemEnum.Venison].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Venison].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.BakedChicken] <= 0)
        {
            m_buttons[2].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[2].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Jibie] <= 0)
        {
            m_buttons[3].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[3].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.WaterBottle] <= 0)
        {
            m_buttons[4].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[4].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Herbs] <= 0)
        {
            m_buttons[5].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[5].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.HealingDrug] <= 0)
        {
            m_buttons[6].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[6].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.EndMaterial] <= 0)
        {
            m_buttons[7].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[7].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.PetBottles] <= 0)
        {
            m_buttons[8].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[8].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.BrokenBottle] <= 0)
        {
            m_buttons[9].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[9].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.AluminumCan] <= 0)
        {
            m_buttons[10].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[10].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.PieceOfCloth] <= 0)
        {
            m_buttons[11].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[11].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Stone] <= 0)
        {
            m_buttons[12].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[12].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.DeadBranch] <= 0)
        {
            m_buttons[13].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[13].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Straw] <= 0)
        {
            m_buttons[14].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[14].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.SuppleBranches] <= 0)
        {
            m_buttons[15].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[15].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.DurableBranches] <= 0)
        {
            m_buttons[16].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[16].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.IronPiece] <= 0)
        {
            m_buttons[17].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[17].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.BearClaws] <= 0)
        {
            m_buttons[18].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[18].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.FragmentOfOre] <= 0)
        {
            m_buttons[19].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[19].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.HardOre] <= 0)
        {
            m_buttons[(int)ItemEnum.HardOre].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[20].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.DurableIvy] <= 0)
        {
            m_buttons[(int)ItemEnum.DurableIvy].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.DurableIvy].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Wood] <= 0)
        {
            m_buttons[(int)ItemEnum.Wood].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Wood].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Aluminium] <= 0)
        {
            m_buttons[(int)ItemEnum.Aluminium].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Aluminium].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.KnifeCore] <= 0)
        {
            m_buttons[(int)ItemEnum.KnifeCore].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.KnifeCore].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.PickaxeCore] <= 0)
        {
            m_buttons[(int)ItemEnum.PickaxeCore].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.PickaxeCore].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.AxeCore] <= 0)
        {
            m_buttons[(int)ItemEnum.AxeCore].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.AxeCore].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.AluminiumKnife] <= 0 || HaveItemManager.Instance.itemsCurrentHP[0] <= 0)
        {
            m_buttons[(int)ItemEnum.AluminiumKnife].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.AluminiumKnife].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.FragileKnife] <= 0 || HaveItemManager.Instance.itemsCurrentHP[1] <= 0)
        {
            m_buttons[(int)ItemEnum.FragileKnife].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.FragileKnife].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.SmallKnife] <= 0 || HaveItemManager.Instance.itemsCurrentHP[2] <= 0)
        {
            m_buttons[(int)ItemEnum.SmallKnife].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.SmallKnife].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Machete] <= 0 || HaveItemManager.Instance.itemsCurrentHP[3] <= 0)
        {
            m_buttons[(int)ItemEnum.Machete].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Machete].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.GlassPickaxe] <= 0 || HaveItemManager.Instance.itemsCurrentHP[4] <= 0)
        {
            m_buttons[(int)ItemEnum.GlassPickaxe].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.GlassPickaxe].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Pickaxe2] <= 0 || HaveItemManager.Instance.itemsCurrentHP[5] <= 0)
        {
            m_buttons[(int)ItemEnum.Pickaxe2].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Pickaxe2].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Trap] <= 0)
        {
            m_buttons[(int)ItemEnum.Trap].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Trap].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Axe] <= 0 || HaveItemManager.Instance.itemsCurrentHP[6] <= 0)
        {
            m_buttons[(int)ItemEnum.Axe].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Axe].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Hammer] <= 0 || HaveItemManager.Instance.itemsCurrentHP[7] <= 0)
        {
            m_buttons[(int)ItemEnum.Hammer].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Hammer].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Bridge] <= 0)
        {
            m_buttons[(int)ItemEnum.Bridge].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Bridge].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Fire] <= 0)
        {
            m_buttons[(int)ItemEnum.Fire].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[(int)ItemEnum.Fire].gameObject.SetActive(true);
        }
    }
}
