using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialControl : MonoBehaviour
{
    [SerializeField] GameObject[] tutorialPage;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject backButton;
    [SerializeField] Text pageNumberText;
    int pageNumber = 0;
    private void Start()
    {
        OnClickTutorialOpen();
    }
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
            pageNumber = tutorialPage.Length - 1;
            nextButton.SetActive(false);
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
        }
        else
        {
            backButton.SetActive(true);
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
        }
        pageNumberText.text = (pageNumber + 1).ToString() + "/" + tutorialPage.Length.ToString();
    }
    public void OnClickBackPage()
    {
        pageNumber--;
        if (pageNumber <= 0)
        {
            pageNumber = 0;
            backButton.SetActive(false);
            CloseAllPage();
            tutorialPage[0].SetActive(true);
        }
        else
        {
            nextButton.SetActive(true);
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
        }
        pageNumberText.text = (pageNumber + 1).ToString() + "/" + tutorialPage.Length.ToString();
    }
    public void OnClickTutorialClose()
    {
        gameObject.SetActive(false);
    }
    public void OnClickTutorialOpen()
    {
        gameObject.SetActive(true);
        if (tutorialPage.Length > 1)
        {
            CloseAllPage();
            tutorialPage[pageNumber].SetActive(true);
            if (pageNumber == 0)
            {
                backButton.SetActive(false);
                nextButton.SetActive(true);
            }
            else if (pageNumber == tutorialPage.Length - 1)
            {
                nextButton.SetActive(false);
                backButton.SetActive(true);
            }
            pageNumberText.text = (pageNumber + 1).ToString() + "/" + tutorialPage.Length.ToString();
        }
        else
        {
            tutorialPage[0].SetActive(true);
            nextButton.SetActive(false);
            backButton.SetActive(false);
            pageNumberText.text = "";
        }
    }
}
