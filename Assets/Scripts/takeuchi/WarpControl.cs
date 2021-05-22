using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpControl : MonoBehaviour
{
    [SerializeField] WarpControl m_targetWarpControl;
    float warpTime = 4f;
    [SerializeField] GoalMaster goalMaster = null;
    float warpTimer = 0;
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
                if (!warp&& warpTimer <= warpTime - 1.4f)
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
                if (warp&& warpTimer < 0.3f)
                {
                    Player.Instance.PlayerAngleChange(MoveAngle.Right);
                    warp = false;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        Player.Instance.MoveStart();
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
                StartCoroutine(WarpPlayer());
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
