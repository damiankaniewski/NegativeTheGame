using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private int nextLevel = 0;
    private bool isFinished = false;
    
    private void Start()
    {
        nextLevel = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isFinished && col.CompareTag("Player"))
        {
            GameManager.Instance.NextLevel(nextLevel);
            isFinished = true;
        }
        
    }
}