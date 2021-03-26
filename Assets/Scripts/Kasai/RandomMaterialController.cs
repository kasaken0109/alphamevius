using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialController : MonoBehaviour
{
    [SerializeField] ItemEnum[] m_item;
    [SerializeField] int m_size = Random.Range(0,5);
    [SerializeField] int m_MaxDropNum = 5;
    [SerializeField] Transform[] m_dropPoint;
    // Start is called before the first frame update
    void Start()
    {
        switch (m_size)
        {
            case 0: 
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
