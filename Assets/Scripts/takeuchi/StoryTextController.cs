using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] StoryTextBox[] textBoxs;
    [SerializeField] GameObject nextBotton;
    [SerializeField] float textSpeed = 0.1f;
    string[] storyTextList;
    bool viewStory = false;
    int messageIndexNumber = 0;
    int messageCount = 0;
    private void Start()
    {
        nextBotton.SetActive(false);
        SetStory(0);
        StartCoroutine(ViewStory());
    }
    public void SetStory(int storyNumber)
    {
        if (storyNumber >= textBoxs.Length)
        {
            return;
        }
        storyTextList = textBoxs[storyNumber].GetStory();
    }
    private IEnumerator ViewStory()
    {
        viewStory = true;
        storyText.text = "";
        while (storyTextList[messageIndexNumber].Length > messageCount)
        {
            storyText.text += storyTextList[messageIndexNumber][messageCount];
            messageCount++;
            yield return new WaitForSeconds(textSpeed);
        }
        viewStory = false;
        nextBotton.SetActive(true);
    }
    public void OnClickNext()
    {
        if (viewStory)
        {
            Skip();
        }
        else
        {
            NextStory();
        }
    }
    private void Skip()
    {
        StopAllCoroutines();
        storyText.text = storyTextList[messageIndexNumber];
        viewStory = false;
        nextBotton.SetActive(true);
    }
    private void NextStory()
    {
        nextBotton.SetActive(false);
        messageIndexNumber++;
        messageCount = 0;
        if (messageIndexNumber < storyTextList.Length)
        {
            StartCoroutine(ViewStory());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
