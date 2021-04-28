﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader = null;
    [SerializeField] string m_sceneName = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.LoadScene(m_sceneName);
    }
}
