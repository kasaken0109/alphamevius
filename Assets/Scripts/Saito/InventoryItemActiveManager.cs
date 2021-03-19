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
            m_buttons[0].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[0].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Venison] <= 0)
        {
            m_buttons[1].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[1].gameObject.SetActive(true);
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
            m_buttons[20].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[20].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.DurableIvy] <= 0)
        {
            m_buttons[21].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[21].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Wood] <= 0)
        {
            m_buttons[22].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[22].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Aluminium] <= 0)
        {
            m_buttons[23].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[23].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.KnifeCore] <= 0)
        {
            m_buttons[24].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[24].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.PickaxeCore] <= 0)
        {
            m_buttons[25].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[25].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.AxeCore] <= 0)
        {
            m_buttons[26].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[26].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.AluminiumKnife] <= 0)
        {
            m_buttons[27].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[27].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.FragileKnife] <= 0)
        {
            m_buttons[28].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[28].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.SmallKnife] <= 0)
        {
            m_buttons[29].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[29].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Machete] <= 0)
        {
            m_buttons[30].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[30].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Pickaxe1] <= 0)
        {
            m_buttons[31].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[31].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Pickaxe2] <= 0)
        {
            m_buttons[32].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[32].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Trap] <= 0)
        {
            m_buttons[33].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[33].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Axe] <= 0)
        {
            m_buttons[34].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[34].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Hammer] <= 0)
        {
            m_buttons[35].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[35].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Bridge] <= 0)
        {
            m_buttons[36].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[36].gameObject.SetActive(true);
        }
        if (ItemManage.Instance.itemList[ItemEnum.Fire] <= 0)
        {
            m_buttons[37].gameObject.SetActive(false);
        }
        else
        {
            m_buttons[37].gameObject.SetActive(true);
        }
    }
}
