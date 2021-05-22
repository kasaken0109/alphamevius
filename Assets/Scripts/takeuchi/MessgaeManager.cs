using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessgaeManager : MonoBehaviour
{
    [SerializeField] Text stageTargetText;
    //[SerializeField] Text stageSabText;
    [SerializeField] Text messageText;
    [SerializeField] Image messageIcon;
    [SerializeField] RectTransform messageBox;
    [SerializeField] float viweTime = 1f;
    [SerializeField] Image backImage;
    float viweTimer;
    static MessgaeManager instance;
    float viwePositionY = -500;
    float imageClearScale = 0f;
    bool viweMode = false;
    bool viwe;
    Color textColor;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        textColor = messageText.color;
        messageBox.transform.localPosition = new Vector2(0, -500);
    }
    void Update()
    {
        if (!viwe)
        {
            return;
        }   
        if (viweMode)
        {
            if (viwePositionY < 0)
            {
                viwePositionY += 600f * Time.deltaTime;
                if (viwePositionY >= 0)
                {
                    viwePositionY = 0;
                    viweTimer = viweTime;
                }
            }
            if (imageClearScale < 1)
            {
                imageClearScale += Time.deltaTime;
                if (imageClearScale >= 1)
                {
                    imageClearScale = 1f;
                }
            }            
        }
        else
        {
            if (imageClearScale > 0)
            {
                imageClearScale -= Time.deltaTime;
                if (imageClearScale <= 0)
                {
                    imageClearScale = 0f;
                    messageBox.transform.localPosition = new Vector2(0, -500);
                    viwe = false;
                    return;
                }
            }
        }
        messageText.color = new Color(1, 1, 1, imageClearScale) * textColor;
        messageIcon.color = new Color(1, 1, 1, imageClearScale);
        backImage.color = new Color(1, 1, 1, imageClearScale);
        messageBox.transform.localPosition = new Vector2(0, viwePositionY);        
        if (viweTimer > 0)
        {
            viweTimer -= Time.deltaTime;
            if (viweTimer <= 0)
            {
                viweTimer = 0;
                viweMode = false;
            }
        }
    }
    public static void ViweMessage(string viweText)
    {
        instance.messageText.text = viweText;
        instance.messageIcon.sprite = NewItemManager.Instance.GetSprite(0);
        StartViwe();
    }
    public static void ViweMessage(string viweText,int itemID)
    {
        instance.messageText.text = viweText;
        instance.messageIcon.sprite = NewItemManager.Instance.GetSprite(itemID);
        StartViwe();
    }
    public static void ViweMessage(string viweText, Sprite viweIcon)
    {
        instance.messageText.text = viweText;
        instance.messageIcon.sprite = viweIcon;
        StartViwe();
    }
    static void StartViwe()
    {
        instance.imageClearScale = 0f;
        instance.viwePositionY = -500f;
        instance.viweTimer = instance.viweTime;
        instance.viweMode = true;
        instance.viwe = true;
    }
}
