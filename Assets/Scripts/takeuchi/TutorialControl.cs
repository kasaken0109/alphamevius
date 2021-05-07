using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPage;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject backButton;
    int pageNumber;
    void CloseAllPage()
    {
        foreach (var item in tutorialPage)
        {
            item.SetActive(false);
        }
    }
    public void OnClickNextPage()
    {
        if (tutorialPage.Length - 1 < 0)
        {
            return;
        }
        pageNumber++;
        if (pageNumber >= tutorialPage.Length - 1)
        {
            nextButton.SetActive(false);
            tutorialPage[tutorialPage.Length - 1].SetActive(true);
        }
        else
        {
            backButton.SetActive(true);
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
        }
    }
    public void OnClickBackPage()
    {
        pageNumber--;
        if (pageNumber <= 0)
        {
            backButton.SetActive(false);
            tutorialPage[0].SetActive(true);
        }
        else
        {
            nextButton.SetActive(true);
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
        }
    }
}
