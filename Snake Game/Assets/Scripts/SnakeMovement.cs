//------------------------------------------------------------------------------
//
// File Name:	SnakeMovement.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    Passion Project
// Course:	    WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode forwardKey = KeyCode.W;

    private int dirrection = 0;

    public float minSpeed = 0.5f;
    public float maxSpeed = 2;

    public float maxRotation = 1;
    public float rotationAcceleration = 0.1f;
    public float currentRotationAmount = 0;


    Rigidbody2D snakeHeadRB;

    // Start is called before the first frame update
    void Start()
    {
        snakeHeadRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get dirrection
        if (Input.GetKeyDown(leftKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKeyDown(rightKey))
        {
            dirrection = 1;
        }
        else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            dirrection = 1;
        }
        else if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = 0;
        }        

        // Movement
        if (Input.GetKey(forwardKey))
        {
            snakeHeadRB.velocity = transform.up * maxSpeed;
        }
        else
        {
            snakeHeadRB.velocity = transform.up * minSpeed;
        }


        // Rotation
        if (dirrection == -1)
        {
            currentRotationAmount -= rotationAcceleration;
            if (currentRotationAmount < -maxRotation)
            {
                currentRotationAmount = -maxRotation;
            }
        }
        else if (dirrection == 1)
        {
            currentRotationAmount += rotationAcceleration;
            if (currentRotationAmount > maxRotation)
            {
                currentRotationAmount = maxRotation;
            }
        }
        else
        {
            currentRotationAmount = 0;
        }

        snakeHeadRB.transform.Rotate(0, 0, -currentRotationAmount, Space.Self);
    }
}
