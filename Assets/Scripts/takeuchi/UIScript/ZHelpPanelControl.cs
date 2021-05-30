using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZHelpPanelControl : MonoBehaviour
{
    [SerializeField] TutorialControl[] tutorials;
    public void AllClose()
    {
        foreach (var item in tutorials)
        {
            item.StartOff();
            item.OnClickTutorialClose();
        }
    }
    public void OnClickTragetOpen(int traget)
    {
        AllClose();
        tutorials[traget].OnClickTutorialOpen();
    }
}
