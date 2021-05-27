using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpControl : MonoBehaviour
{
    [SerializeField] WarpControl m_targetWarpControl;
    float warpTime = 1f;
    [SerializeField] GoalMaster goalMaster = null;
    float warpTimer = 0;
    [SerializeField] ZFade fadeItem;
    public bool WarpNow { get; set; }
    private IEnumerator WarpPlayer()
    {
        bool warp = false;
        warpTimer = warpTime;
        while (warpTimer > 0)
        {
            Player.Instance.MoveStop();
            warpTimer -= Time.deltaTime;
            if (warpTimer > warpTime / 2f)
            {
                ScreenEffecter.Instance.FadeOut();
                if (!warp && warpTimer <= warpTime - 1.4f)
                {
                    Player.Instance.PlayerAngleChange(MoveAngle.Left);
                    Player.Instance.transform.position = m_targetWarpControl.transform.position;
                    warp = true;
                }
            }
            else
            {
                warpTimer += 0.2f * Time.deltaTime;
                if (warpTimer < 1)
                {
                    ScreenEffecter.Instance.FadeIn();
                }
                if (warp && warpTimer < 0.3f)
                {
                    Player.Instance.PlayerAngleChange(MoveAngle.Right);
                    warp = false;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        Player.Instance.MoveStart();
    }
    private IEnumerator WarpPlayer2()
    {
        Player.Instance.MoveStop();
        fadeItem.StartFadeOut();
        while (fadeItem.FadeNow)
        {
            yield return new WaitForEndOfFrame();
        }
        Player.Instance.transform.position = m_targetWarpControl.transform.position;
        StartCoroutine(WarpPlayer3());
    }
    private IEnumerator WarpPlayer3()
    {
        warpTimer = warpTime;
        while (warpTimer > 0)
        {
            warpTimer -= Time.deltaTime;
            if (warpTimer <= 0)
            {
                warpTimer = 0;

            }
            yield return new WaitForEndOfFrame();
        }
        //Player.Instance.PlayerAngleChange(MoveAngle.Left);
        StartCoroutine(WarpPlayer4());
    }
    
    private IEnumerator WarpPlayer4()
    {
        //Player.Instance.PlayerAngleChange(MoveAngle.Right);
        fadeItem.StartFadeIn();
        while (fadeItem.FadeNow)
        {
            yield return new WaitForEndOfFrame();
        }
        Player.Instance.MoveStart();
        fadeItem.FadeControlEnd();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!WarpNow)
            {
                if (goalMaster)
                {
                    goalMaster.GoalCheck();
                }
                m_targetWarpControl.WarpNow = true;
                Player.Instance.MoveStop();
                StartCoroutine(WarpPlayer2());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            WarpNow = false;
        }
    }
}
