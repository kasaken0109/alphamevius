using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ItemInventory;
    [SerializeField] GameObject CraftInventory;
    [SerializeField] GameObject RecycleInventory;
    [SerializeField] GameObject CookingInventory;
    private bool open;
    void Start()
    {
        ItemInventory.SetActive(false);
        CraftInventory.SetActive(false);
        RecycleInventory.SetActive(false);
        CookingInventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (!open)
            {
                ItemInventory.SetActive(true);
                CraftInventory.SetActive(false);
                RecycleInventory.SetActive(false);
                CookingInventory.SetActive(false);
                open = true;
            }
            else
            {
                ItemInventory.SetActive(false);
                CraftInventory.SetActive(false);
                RecycleInventory.SetActive(false);
                CookingInventory.SetActive(false);
                open = false;
            }
        }
        if (Input.GetButtonDown("Craft"))
        {
            if (!open)
            {
                ItemInventory.SetActive(false);
                CraftInventory.SetActive(true);
                RecycleInventory.SetActive(false);
                CookingInventory.SetActive(false);
                open = true;
            }
            else
            {
                ItemInventory.SetActive(false);
                CraftInventory.SetActive(false);
                RecycleInventory.SetActive(false);
                CookingInventory.SetActive(false);
                open = false;
            }
        }
        if (Input.GetButtonDown("Recycle"))
        {
            if (!open)
            {
                ItemInventory.SetActive(false);
                CraftInventory.SetActive(false);
                RecycleInventory.SetActive(true);
                CookingInventory.SetActive(false);
                open = true;
            }
            else
            {
                ItemInventory.SetActive(false);
                CraftInventory.SetActive(false);
                RecycleInventory.SetActive(false);
                CookingInventory.SetActive(false);
                open = false;
            }
        }
    }

    public void OnClickCooking()
    {
        if (!open)
        {
            ItemInventory.SetActive(false);
            CraftInventory.SetActive(false);
            RecycleInventory.SetActive(false);
            CookingInventory.SetActive(true);
            open = true;
        }
        else
        {
            ItemInventory.SetActive(false);
            CraftInventory.SetActive(false);
            RecycleInventory.SetActive(false);
            CookingInventory.SetActive(false);
            open = false;
        }
    }
}
