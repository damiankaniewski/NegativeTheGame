using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CameraMovement cameraMovement;
    public GameObject groundCheck;
    public float jumpForce = 3;
    public float moveForce = 0.05f;
    
    
    private bool moveRight;
    private bool dontMove = true;

    public Vector2 startingPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(true);
        }

        HandleMoving();
        
    }

    public void Jump(float jumpModifier)
    {
        rb.velocity = Vector3.zero;
        Debug.Log("jump");
        rb.AddForce(transform.up * (jumpForce * jumpModifier), ForceMode2D.Impulse);
    }

    public void Move(bool direction)
    {
        if (direction)
        {
            transform.position += new Vector3(moveForce, 0);
        }
        else
        {
            transform.position += new Vector3(-moveForce, 0);
        }

        HandleMoving();
    }

    void HandleMoving()
    {
        if (!dontMove)
        {
            if (moveRight)
            {
                MoveRight();
            }
            else if (!moveRight)
            {
                MoveLeft();
            }
        }
    }

    public void AllowMovement(bool movement)
    {
        dontMove = false;
        moveRight = movement;
    }

    public void DontAllowMovement()
    {
        dontMove = true;
    }

    public void MoveRight()
    {
        transform.position += new Vector3(moveForce, 0);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-moveForce, 0);
    }

    public void Obstacle()
    {
        transform.position = startingPos;
    }
}