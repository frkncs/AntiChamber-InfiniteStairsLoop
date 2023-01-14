using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    #region Variables
    
    // Public Variables
    
    // Private Variables
    private Transform playerStartTransform;
    private Transform _playerTransform;
    
    #endregion Variables

    private void Awake()
    {
        playerStartTransform = GameObject.FindGameObjectWithTag("StartPosition").transform;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTransform.position = playerStartTransform.position;
        }
    }
}
