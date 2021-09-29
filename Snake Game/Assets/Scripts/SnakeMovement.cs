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

    public float maxRotationSlow = 0.4f;
    public float maxRotationFast = 0.6f;
    public float rotationAcceleration = 0.1f;
    private float currentRotationAmount = 0;


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

            if (dirrection == -1)
            {
                currentRotationAmount -= rotationAcceleration;
                if (currentRotationAmount < -maxRotationFast)
                {
                    currentRotationAmount = -maxRotationFast;
                }
            }
            else if (dirrection == 1)
            {
                currentRotationAmount += rotationAcceleration;
                if (currentRotationAmount > maxRotationFast)
                {
                    currentRotationAmount = maxRotationFast;
                }
            }
            else
            {
                currentRotationAmount = Mathf.Lerp(currentRotationAmount, 0, rotationAcceleration);
            }
        }
        else
        {
            snakeHeadRB.velocity = transform.up * minSpeed;

            if (dirrection == -1)
            {
                currentRotationAmount -= rotationAcceleration;
                if (currentRotationAmount < -maxRotationSlow)
                {
                    currentRotationAmount = -maxRotationSlow;
                }
            }
            else if (dirrection == 1)
            {
                currentRotationAmount += rotationAcceleration;
                if (currentRotationAmount > maxRotationSlow)
                {
                    currentRotationAmount = maxRotationSlow;
                }
            }
            else
            {
                currentRotationAmount = Mathf.Lerp(currentRotationAmount, 0, rotationAcceleration);
                
            }
        }       

        snakeHeadRB.transform.Rotate(0, 0, -currentRotationAmount, Space.Self);
    }
}
