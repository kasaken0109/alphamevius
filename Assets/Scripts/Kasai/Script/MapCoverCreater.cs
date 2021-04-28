using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCoverCreater : MonoBehaviour
{
    [SerializeField] GameObject m_coverPrefab = null;
    [SerializeField] Vector2 m_startPosition;
    [SerializeField] int maxX;
    [SerializeField] int maxY;
    [SerializeField] float m_tileScale;
    private void Start()
    {
        CreateCover();
    }
    public void CreateCover()
    {
        for (int i = 0; i < maxY; i++)
        {
            for (int k = 0; k < maxX; k++)
            {
                GameObject cover = Instantiate(m_coverPrefab);
                cover.transform.position = new Vector2(k * m_tileScale, i * m_tileScale) + m_startPosition;
                cover.transform.localScale *= m_tileScale;
            }
        }
    }
}
