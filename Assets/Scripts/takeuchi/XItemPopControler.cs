using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XItemPopControler : MonoBehaviour
{
    public static XItemPopControler Instance { get; private set; }
    [SerializeField] GameObject[] popItemPrefabs;
    [SerializeField] Transform[] popPositions;
    [SerializeField] int popNumber = 10;
    bool[] popPos;
    List<Transform> popPositionList = new List<Transform>();
    bool start;
    private void Awake()
    {
        Instance = this;
    }
    //void Start()
    //{
    //    popPos = new bool[popPositions.Length];
    //    for (int i = 0; i < popNumber; i++)
    //    {
    //        PopSet();
    //    }
    //    for (int a = 0; a < popPos.Length; a++)
    //    {
    //        if (popPos[a])
    //        {
    //            int item = Random.Range(0, popItemPrefabs.Length);
    //            Instantiate(popItemPrefabs[item]).transform.position = popPositions[a].position;
    //        }
    //    }
    //}
    private void LateUpdate()
    {
        if (start)
        {
            return;
        }
        popPos = new bool[popPositionList.Count];
        for (int i = 0; i < popNumber; i++)
        {
            PopSet(0);
        }
        for (int a = 0; a < popPos.Length; a++)
        {
            if (popPos[a])
            {
                int item = Random.Range(0, popItemPrefabs.Length);
                Instantiate(popItemPrefabs[item]).transform.position = popPositionList[a].position;
            }
        }
        start = true;
    }
    public void SetPosition(Transform pos)
    {
        popPositionList.Add(pos);
    }
    void PopSet()
    {
        int rPos = Random.Range(0, popPositions.Length);
        if (popPos[rPos])
        {
            PopSet();
        }
        else
        {
            popPos[rPos] = true;
        }
    }
    void PopSet(int i)
    {
        int rPos = Random.Range(0, popPositionList.Count);
        if (popPos[rPos])
        {
            PopSet(0);
        }
        else
        {
            popPos[rPos] = true;
        }
    }
}
