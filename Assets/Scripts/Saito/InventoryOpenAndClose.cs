using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpenAndClose : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject inventoryPanel;
    public void ChangeInventoryUI()
    {
        
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
            inventoryPanel.SetActive(true);
        }
    }
}
