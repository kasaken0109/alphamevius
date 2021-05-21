using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CampFireManager Instance { get; private set; }
    [SerializeField] ActionRange actionRange = null;
    [SerializeField] GameObject m_animCamp = null;
    [SerializeField] GameObject m_Camp = null;
    [SerializeField] Transform m_player = null;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// 寝袋を設置するときに呼ばれる関数
    /// </summary>
    /// <param name="m_player">プレイヤーの位置</param>
    public void CreateCamp()
    {
        if (GameObject.Find("tent"))
        {
            m_Camp.SetActive(false);
            Instantiate(m_animCamp, transform.position, transform.rotation);
        }
        transform.position = m_player.position;
        m_Camp.SetActive(true);
    }

}
