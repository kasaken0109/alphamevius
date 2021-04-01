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
    private float playerMaxHP;
    private float R = 0;
    private float G = 1;
    private int B = 0;
    float testTimer = 0;
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
        //HPtest();
        HPGaugeControl();
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
    private void HPGaugeControl()
    {
        int p = PlayerManager.Instance.CurrentHP;
        float pm = p / playerMaxHP;
        HPGauge.fillAmount = pm;
        if (pm >= 0.5f)
        {
            R = 2 - 2 * pm;
            G = 1;
        }
        else
        {
            R = 1;
            G = 2 * pm;
        }
        HPGauge.color = new Color(R, G, B);
    }
    void HPtest()
    {
        int i = PlayerManager.Instance.CurrentHP;
        testTimer += Time.deltaTime;
        if (testTimer >= 0.1f)
        {
            testTimer = 0;
            if (i == 100)
            {
                PlayerManager.Instance.Damage(100);
            }
            else
            {
                PlayerManager.Instance.HealingHP(1);
            }
        }
    }
}
