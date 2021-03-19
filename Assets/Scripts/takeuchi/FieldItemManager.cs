using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItemManager : MonoBehaviour
{
    public static FieldItemManager Instance { get; private set; }
    [SerializeField] FieldItem[] fieldItems;
    private void Awake()
    {
        Instance = this;
    }
}
