using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XFieldCreater : MonoBehaviour
{
    [SerializeField] GameObject[] createIslands;
    [SerializeField] Transform[] createPositions;
    int[] cPos;
    void Start()
    {
        if (createIslands.Length > createPositions.Length)
        {
            Debug.Log("生成位置不足");
            return;
        }
        cPos = new int[createPositions.Length];
        for (int a = 0; a < cPos.Length; a++)
        {
            cPos[a] = -1;
        }
        for (int i = 0; i < createIslands.Length; i++)
        {
            IslandSetPos(i);
        }
        for (int k = 0; k < cPos.Length; k++)
        {
            if (cPos[k] >= 0)
            {
                Instantiate(createIslands[cPos[k]]).transform.position = createPositions[k].position;
            }
        }
    }
    void IslandSetPos(int number)
    {
        int rPos = Random.Range(0, createPositions.Length);
        if (cPos[rPos] >= 0)
        {
            IslandSetPos(number);
        }
        else
        {
            cPos[rPos] = number;
        }
    }
}
