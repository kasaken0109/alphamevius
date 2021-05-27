using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaster : MonoBehaviour
{
    [SerializeField] GameObject shadowObject;
    [SerializeField] int missionItemNumber = 50;
    [SerializeField] GameObject goal;
    [SerializeField] GoalGate gate;
    [SerializeField] GameObject goalItemObject;
    [SerializeField] float movePointY = 2f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float itemGetWaitTime = 2f;
    [SerializeField] SceneLoader sceneLoader = null;
    float itemPoint = 0;
    bool goalF;
    bool goalStart;
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
            if (goalStart)
            {
                return;
            }
            if (collision.tag == "Player")
            {
                goalStart = true;
                goal.SetActive(true);
                StartCoroutine(GoalItemMove());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (goalF)
        {
            if (goalStart)
            {
                return;
            }
            if (collision.tag == "Player")
            {
                goalStart = true;
                goal.SetActive(true);
                StartCoroutine(GoalItemMove());
            }
        }
    }
    private IEnumerator GoalItemMove()
    {
        Player.Instance.AllStop();
        itemPoint = -1.5f;
        while (itemPoint < movePointY)
        {
            itemPoint += moveSpeed * Time.deltaTime;
            goalItemObject.transform.localPosition = new Vector3(goalItemObject.transform.localPosition.x, itemPoint , goalItemObject.transform.localPosition.z);
            yield return new WaitForEndOfFrame();
        }
        MessgaeManager.ViweMessage("ラジオの部品を手に入れた", goalItemObject.GetComponent<SpriteRenderer>().sprite);
        StartCoroutine(SceneChangeWait());
    }
    private IEnumerator SceneChangeWait()
    {
        Debug.Log(11);
        int count = 1;
        while (count > 0)
        {
            count--;
            Debug.Log(count);
            yield return new WaitForSecondsRealtime(itemGetWaitTime);
        }
        if (sceneLoader)
        {
            Debug.Log("ww");
            sceneLoader.LoadScene(sceneLoader.m_sceneNameToBeLoaded);
        }
        
    }
}
