using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMark : MonoBehaviour
{
    [SerializeField] RectTransform markPos;
    public static TargetMark Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void CloseInventory()
    {
        markPos.localPosition = new Vector2(2000, 2000);
    }

    public void TargetSet(RectTransform pos)
    {
        markPos.SetParent(pos);
        markPos.localPosition = new Vector2(0, 0);        
    }
}
