using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextController : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] StoryTextBox[] textBoxs;
    string[] storyTextList;
    bool viweStory = false;
    void Update()
    {
        if (!viweStory)
        {
            return;
        }
    }
    public void SetStory(int storyNumber)
    {
        if (storyNumber >= textBoxs.Length)
        {
            return;
        }
        storyTextList = textBoxs[storyNumber].GetStory();
    }
}
