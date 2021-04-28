using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHotbarItem : MonoBehaviour
{
    int ID;
    bool check;
    [SerializeField] Image image;
    [SerializeField] Text haveNumber;
    public void ChangeImage(int ID)
    {
        this.ID = ID;
        image.sprite = NewItemManager.Instance.GetSprite(ID);
    }
}
