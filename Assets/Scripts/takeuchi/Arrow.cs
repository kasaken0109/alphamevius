using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 5f;
    [SerializeField] float flyTime = 1f;
    float flyTimer = 0;
    Vector2 dir = Vector2.zero;
    [SerializeField] Rigidbody2D rB = null;
    bool hit = false;
    void Update()
    {
        flyTimer += Time.deltaTime;
        if (flyTimer >= flyTime)
        {
            Destroy(this.gameObject);
        }
        rB.velocity = dir.normalized * arrowSpeed;
    }
    public void SetArrowDir(Vector2 dir)
    {
        SoundManager.Instance.PlayObjectSE(1);
        PlayerManager.Instance.ExpendHunger(1);
        PlayerManager.Instance.ExpendHydrate(2);
        this.dir = dir;
        transform.rotation = Quaternion.FromToRotation(Vector2.left, dir);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!hit)
            {
                hit = true;
                SoundManager.Instance.PlayObjectSE(8);
                EffectManager.PlayEffect(EffectType.Hit, transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
