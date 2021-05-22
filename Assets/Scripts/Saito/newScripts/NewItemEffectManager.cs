using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItemEffectManager : MonoBehaviour
{
    public static NewItemEffectManager Instance { get; private set; }
    int itemID;
    ToolType toolType = ToolType.None;
    NewItemManager manager = null;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        manager = NewItemManager.Instance;
    }
    public void UseItem()
    {
        switch (toolType)
        {
            case ToolType.None:
                break;
            case ToolType.Knife:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Bow:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Axe:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Hammer:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Machete:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Pickaxe:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.Clothes:
                break;
            case ToolType.Trap:
                break;
            case ToolType.HealingHP:
                PlayerManager.Instance.HealingHP(manager.GetItem(itemID).GetEfficiency());
                NewItemManager.Instance.SubItem(itemID, 1);
                break;
            case ToolType.Torch:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.HealingWater:
                PlayerManager.Instance.HealingHydrate(manager.GetItem(itemID).GetEfficiency());
                NewItemManager.Instance.GetEmptyBottle(manager.GetItem(itemID).GetEfficiency());
                break;
            case ToolType.Bridge:
                break;
            case ToolType.Cooking:
                PlayerManager.Instance.HealingHunger(manager.GetItem(itemID).GetEfficiency());
                break;
            case ToolType.EmptyBottle:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            default:
                break;
        }
    }
    public void UseItem(ZInventoryTools inventoryTool)
    {
        switch (toolType)
        {
            case ToolType.None:
                break;
            case ToolType.Knife:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Bow:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Axe:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Hammer:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Machete:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Pickaxe:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                ZInventoryManager.Instance.EquipmentSet(inventoryTool);
                break;
            case ToolType.Clothes:
                SleepBagManager.Instance.CreateSleepBag();
                inventoryTool.SetItem(0);
                break;
            case ToolType.Bonfire:
                CampFireManager.Instance.CreateCamp();
                inventoryTool.SetItem(0);
                break;
            case ToolType.HealingHP:
                PlayerManager.Instance.HealingHP(manager.GetItem(itemID).GetEfficiency());
                NewItemManager.Instance.SubItem(itemID, 1);
                inventoryTool.SetItem(0);
                break;
            case ToolType.Torch:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.HealingWater:
                PlayerManager.Instance.HealingHydrate(manager.GetItem(itemID).GetEfficiency());
                NewItemManager.Instance.GetEmptyBottle(manager.GetItem(itemID).GetEfficiency());
                break;
            case ToolType.Bridge:
                CreateBridge.Instance.BridgeCreate(inventoryTool);
                break;
            case ToolType.Cooking:
                PlayerManager.Instance.HealingHunger(manager.GetItem(itemID).GetEfficiency());
                break;
            case ToolType.EmptyBottle:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            default:
                break;
        }
    }
    public void SetItem(int ID)
    {
        itemID = ID;
        toolType = manager.GetToolType(ID);
    }
    public void SetUse(int ID)
    {
        itemID = ID;
        toolType = manager.GetToolType(ID);
        UseItem();
    }
    public void SetUse(int ID,ZInventoryTools tool)
    {
        itemID = ID;
        tool.SetItem(ID);
        toolType = manager.GetToolType(ID);
        UseItem(tool);
    }
    private void RemoveItem()
    {
        itemID = 0;
        toolType = ToolType.None;
    }
}
