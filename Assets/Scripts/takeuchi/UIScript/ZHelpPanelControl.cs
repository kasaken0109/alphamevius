using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZHelpPanelControl : MonoBehaviour
{
    [SerializeField] TutorialControl[] tutorials;
    private void Start()
    {
        AllClose();
    }
    public void AllClose()
    {
        foreach (var item in tutorials)
        {
            item.OnClickTutorialClose();
        }
    }
    public void OnClickTragetOpen(int traget)
    {
        AllClose();
        tutorials[traget].OnClickTutorialOpen();
    }
}
