using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaster : MonoBehaviour
{
    [SerializeField] GameObject shadowObject;
    [SerializeField] int missionItemNumber = 50;
    [SerializeField] GameObject goal;
    [SerializeField] GoalGate gate;
    bool goalF;
    public void GoalCheck()
    {
        if (NewItemManager.Instance.GetItem(1).GetHaveNumber() < missionItemNumber)
        {
            return;
        }
        else
        {
            shadowObject.SetActive(false);
            goalF = true;
            goal.SetActive(false);
            gate.OpenGoalGate();
        }
    }
    private void Update()
    {
        if (goalF)
        {
            return;
        }
        GoalCheck();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (goalF)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("ステージクリア!");
                //ステージクリア処理
                goal.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goalF)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("ステージクリア!");
                //ステージクリア処理
                goal.SetActive(true);
            }
        }
        else
        {

            if (collision.tag == "Player")
            {
                MessgaeManager.ViweMessage("メビウスの欠片が" + missionItemNumber + "個必要",NewItemManager.Instance.GetSprite(1));
            }
        }
    }
}
