using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Surface"))
        {
            playerMovement.Jump(1);
        }

        if (col.CompareTag("NoJump"))
        {
            playerMovement.Jump(0.05f);
        }
    }
}
