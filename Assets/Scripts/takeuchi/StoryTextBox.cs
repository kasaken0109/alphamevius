using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryText", menuName = "StoryText")]
public class StoryTextBox : ScriptableObject
{
    [SerializeField] string[] storyText;
    [SerializeField] Sprite[] imageList;
    [SerializeField] int[] imageCount;
    public string[] GetStory()
    {
        return storyText;
    }
    public Sprite GetSprite(int imageNumber)
    {
        return imageList[imageNumber];
    }
    public int[] GetImageCount()
    {
        return imageCount;
    }
}
