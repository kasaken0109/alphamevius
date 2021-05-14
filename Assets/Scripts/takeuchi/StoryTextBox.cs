using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryText", menuName = "StoryText")]
public class StoryTextBox : ScriptableObject
{
    [SerializeField] string[] storyText;
    public string[] GetStory()
    {
        return storyText;
    }
}
