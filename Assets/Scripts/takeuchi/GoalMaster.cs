using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaster : MonoBehaviour
{
    [SerializeField] GameObject shadowObject;
    [SerializeField] int missionItemNumber = 50;
    bool goalF;
    public void GoalCheck()
    {
        if (NewItemManager.Instance.GetItem(1).GetHaveNumber() < missionItemNumber)
        {
            shadowObject.SetActive(true);
            goalF = false;
        }
        else
        {
            shadowObject.SetActive(false);
            goalF = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (goalF)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("ステージクリア!");
                //ステージクリア処理
            }
        }
    }
}
