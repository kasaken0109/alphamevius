using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class NewHintController : MonoBehaviour
{
    [SerializeField] GameObject m_hintIcon;
    [SerializeField] string m_playerName = "Player";
    [SerializeField] float m_hintDistance = 10f;
    Animation m_animation = null;
    GameObject m_player;
    // Start is called before the first frame update
    void Start()
    {
        m_animation = GetComponent<Animation>();
        m_player = GameObject.Find(m_playerName);
        m_hintIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float m_distance = Vector3.Distance(transform.position, m_player.transform.position);
        if (m_distance <= m_hintDistance)
        {
            m_animation.Play();
            if (m_distance <= m_hintDistance / 2)
            {
                m_hintIcon.SetActive(true);
            }
        }
        else
        {
            m_hintIcon.SetActive(false);
        }

    }
}
