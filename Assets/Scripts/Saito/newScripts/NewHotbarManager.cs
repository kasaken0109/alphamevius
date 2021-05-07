using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHotbarManager : MonoBehaviour
{
    [SerializeField] NewHotbarItem[] hotbarItems;
    bool[] haveTool = new bool[10];
    public static NewHotbarManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            HotbarUse(0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            HotbarUse(1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            HotbarUse(2);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            HotbarUse(3);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            HotbarUse(4);
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            HotbarUse(5);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            HotbarUse(6);
        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            HotbarUse(7);
        }
        if (Input.GetKeyDown(KeyCode.F9))
        {
            HotbarUse(8);
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            HotbarUse(9);
        }
    }
    public void HotbarUse(int number)
    {
        NewItemEffectManager.Instance.SetUse(hotbarItems[number].GetID());
    }
    public void SetHotbar(int hotbarID)
    {
        haveTool[hotbarID] = true;
    }
    public void EquipmentTool(int EquipmentID)
    {
        foreach (var item in hotbarItems)
        {
            item.SetEquipmentMark(EquipmentID);
        }
    }
    public void ChangeGray(int ID)
    {
        foreach (var item in hotbarItems)
        {
            if (item.GetID() == ID)
            {
                item.ChangeGray();
            }
        }
    }
    public void ChangeNomaleColor(int ID)
    {
        foreach (var item in hotbarItems)
        {
            if (item.GetID() == ID)
            {
                item.ChangeNomaleColor();
            }
        }
    }
}
