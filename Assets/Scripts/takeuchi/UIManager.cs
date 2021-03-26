using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ItemInventory;
    [SerializeField] GameObject CraftInventory;
    [SerializeField] GameObject RecycleInventory;
    [SerializeField] GameObject CookingInventory;
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
            ItemInventory.SetActive(true);
            CraftInventory.SetActive(false);
            RecycleInventory.SetActive(false);
            CookingInventory.SetActive(false);
        }
        if (Input.GetButtonDown("Craft"))
        {
            ItemInventory.SetActive(false);
            CraftInventory.SetActive(true);
            RecycleInventory.SetActive(false);
            CookingInventory.SetActive(false);
        }
        if (Input.GetButtonDown("Recycle"))
        {
            ItemInventory.SetActive(false);
            CraftInventory.SetActive(false);
            RecycleInventory.SetActive(true);
            CookingInventory.SetActive(false);
        }
    }

    public void OnClickCooking()
    {
        ItemInventory.SetActive(false);
        CraftInventory.SetActive(false);
        RecycleInventory.SetActive(false);
        CookingInventory.SetActive(true);
    }
}
