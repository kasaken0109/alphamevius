using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIconManager : MonoBehaviour
{
    [SerializeField] int itemID = 0;
    Text text;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }
}
