using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMarkControl : MonoBehaviour
{
    [SerializeField] RectTransform markPos;
    public static EMarkControl Instance { get; private set; }
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
        markPos.localPosition = pos.localPosition;
        pos.transform.SetParent(markPos);
    }
}
