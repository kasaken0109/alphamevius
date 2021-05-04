using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XIslandControl : MonoBehaviour
{
    [SerializeField] Transform[] itemPos;
    void Start()
    {
        for (int i = 0; i < itemPos.Length; i++)
        {
            XItemPopControler.Instance.SetPosition(itemPos[i]);
        }
    }
}
