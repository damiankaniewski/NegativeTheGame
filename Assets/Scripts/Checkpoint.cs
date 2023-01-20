using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.ResetPosition(transform.position);
            GetComponent<Animator>().Play("CheckpointDestroy");
            Destroy(gameObject,1);
        }
        
    }
}
