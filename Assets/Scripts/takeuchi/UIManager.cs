using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ItemInventory;
    [SerializeField] GameObject CraftInventory;
    [SerializeField] GameObject RecycleInventory;
    [SerializeField] GameObject CookingInventory;
    [SerializeField] Image HPGauge;
    [SerializeField] Image WGauge;
    [SerializeField] Image HGauge;
    private bool open;
    private int playerMaxHP;
    private float R = 0;
    private float G = 255;
    private int B = 0;

    void Start()
    {
        playerMaxHP = PlayerManager.Instance.GetMaxHP();
        ItemInventory.SetActive(false);
        CraftInventory.SetActive(false);
        RecycleInventory.SetActive(false);
        CookingInventory.SetActive(false);
    }

    void Update()
    {
        int p = PlayerManager.Instance.CurrentHP;
        float pm = playerMaxHP;
        HPGauge.fillAmount = p / pm;
        HPGauge.color = new Color(R, G, B);
        if (Input.GetButtonDown("Menu"))
        {
            if (!open)
            {
                PlayerManager.Instance.Damage(10);
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
