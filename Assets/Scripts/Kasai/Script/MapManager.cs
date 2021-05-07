using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject m_mapCamera = null;
    bool mapActive = false;
    public static MapManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void ActiveMap()
    {
        if (!mapActive)
        {
            NewInventoryManager.Instance.OnClickClose();
            m_mapCamera.SetActive(true);
            mapActive = true;
        }
        else
        {
            m_mapCamera.SetActive(false);
            mapActive = false;
        }
        
    }
    public void CloseMap()
    {
        m_mapCamera.SetActive(false);
        mapActive = false;
    }
}
