using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItemEffectManager : MonoBehaviour
{
    int itemID;
    ToolType toolType = ToolType.None;
    Image image;
    NewItemManager manager = null;
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
                break;
            case ToolType.Torch:
                PlayerManager.Instance.SetEquipmentTool(manager.GetItem(itemID));
                break;
            case ToolType.HealingWater:
                PlayerManager.Instance.HealingHydrate(manager.GetItem(itemID).GetEfficiency());
                break;
            case ToolType.Bridge:
                break;
            case ToolType.Cooking:
                PlayerManager.Instance.HealingHunger(manager.GetItem(itemID).GetEfficiency());
                break;
            default:
                break;
        }
    }
    public void SetItem(int ID)
    {
        itemID = ID;
        toolType = manager.GetToolType(ID);
        image.sprite = manager.GetSprite(ID);
    }
    private void RemoveItem()
    {
        itemID = 0;
        toolType = ToolType.None;
        image.sprite = null;
    }
}
