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
    [SerializeField] Image thisImage;
    [SerializeField] float clearSpeed = 0.1f;
    string[] storyTextList;
    int[] imageIndexCount;
    bool viewStory = false;
    bool viewImage = false;
    int messageIndexNumber = 0;
    int messageCount = 0;
    float imageClearScale = 1;
    int imageNumber = 0;
    int imageCount = 0;
    int storyNumber = 0;
    bool imageEnd;
    private void Start()
    {
        nextBotton.SetActive(false);
        SetStory(storyNumber);
        StartCoroutine(ViewStory());
    }
    public void SetStory(int storyNumber)
    {
        if (storyNumber >= textBoxs.Length)
        {
            return;
        }
        storyTextList = textBoxs[storyNumber].GetStory();
        imageIndexCount = textBoxs[storyNumber].GetImageCount();
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
    private IEnumerator ViewImage()
    {
        viewImage = true;
        storyText.text = "";
        while (imageClearScale > 0)
        {
            imageClearScale -= 0.01f;
            thisImage.color = new Color(1, 1, 1, imageClearScale);
            yield return new WaitForSeconds(clearSpeed);
        }
        StartCoroutine(ViewImage2());
    }
    private IEnumerator ViewImage2()
    {
        thisImage.sprite = textBoxs[storyNumber].GetSprite(imageNumber);
        while (imageClearScale < 1)
        {
            imageClearScale += 0.01f;
            thisImage.color = new Color(1, 1, 1, imageClearScale);
            yield return new WaitForSeconds(clearSpeed);
        }
        viewImage = false;
        StartCoroutine(ViewStory());
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
        if (viewImage)
        {
            return;
        }
        nextBotton.SetActive(false);
        messageIndexNumber++;
        messageCount = 0;
        if (messageIndexNumber < storyTextList.Length)
        {
            if (imageEnd)
            {
                StartCoroutine(ViewStory());
            }
            else
            {
                if (imageIndexCount[imageNumber] > imageCount)
                {
                    imageCount++;
                    StartCoroutine(ViewStory());
                }
                else
                {
                    imageCount = 0;
                    imageNumber++;
                    if (imageNumber < imageIndexCount.Length)
                    {
                        StartCoroutine(ViewImage());
                    }
                    else
                    {
                        imageEnd = true;
                        StartCoroutine(ViewStory());
                    }
                }
            }
        }
        else
        {
            Debug.Log("終了");
        }
    }
}
