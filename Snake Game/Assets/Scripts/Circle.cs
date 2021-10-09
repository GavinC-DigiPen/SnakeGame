//------------------------------------------------------------------------------
//
// File Name:	Circle.cs
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

public class Circle : MonoBehaviour
{
    [Tooltip("The X and Y position that will be rotated around")]
    public Vector2 centerLocation;
    [Tooltip("The X and Y radi")]
    public Vector2 radius = new Vector2(1, 1);
    [Tooltip("The X and Y speed")]
    public Vector2 speed = new Vector2(1, 1);
    

    // Start is called before the first frame update
    void Start()
    {
        centerLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(centerLocation.x + Mathf.Cos(Time.time * speed.x) * radius.x, centerLocation.y + Mathf.Sin(Time.time * speed.y) * radius.y);
    }
}
