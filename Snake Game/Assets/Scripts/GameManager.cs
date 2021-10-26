//------------------------------------------------------------------------------
//
// File Name:	GameManager.cs
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
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int maxSnakeHealth = 40;
    private static int currentSnakeHealth = 0;

    public static UnityEvent OnHealthChange = new UnityEvent();

    public static int MaxSnakeHealth
    {
        get
        {
            return maxSnakeHealth;
        }
        set
        {
            maxSnakeHealth = value;
            OnHealthChange.Invoke();
        }
    }

    public static int CurrentSnakeHealth
    {
        get
        {
            return currentSnakeHealth;
        }
        set
        {
            currentSnakeHealth = value;
            OnHealthChange.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
