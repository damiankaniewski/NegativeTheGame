using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            playerMovement.Obstacle();
        }
    }
}
