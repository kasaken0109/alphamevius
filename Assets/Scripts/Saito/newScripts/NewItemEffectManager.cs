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
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Bow:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Axe:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Hammer:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Machete:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Pickaxe:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.Clothes:
                break;
            case ToolType.Trap:
                break;
            case ToolType.HealingHP:
                break;
            case ToolType.Torch:
                manager.SetEquipmentItem(itemID);
                break;
            case ToolType.HealingWater:
                break;
            case ToolType.Bridge:
                break;
            case ToolType.Cooking:
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
