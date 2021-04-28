using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject m_mapCamera = null;
    bool mapActive = false;
    //[SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveMap()
    {
        Debug.Log("MapActive");
        if (!mapActive)
        {
            m_mapCamera.SetActive(true);
            mapActive = true;
        }
        else
        {
            m_mapCamera.SetActive(false);
            mapActive = false;
        }
        
    }
}
