//------------------------------------------------------------------------------
//
// File Name:	SnakeHealthBar.cs
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
using UnityEngine.UI;
using TMPro;

public class SnakeHealthBar : MonoBehaviour
{
    [Tooltip("The game object that is the health bar")]
    public GameObject healthBar;
    [Tooltip("The TMP for the text object")]
    public TextMeshProUGUI healthNumberText;

    private Vector2 startingPosition;
    private Vector2 startingScale;

    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            startingPosition = healthBar.transform.position;
            startingScale = healthBar.transform.localScale;
            UpdateHealth();
            GameManager.OnHealthChange.AddListener(UpdateHealth);
        }
    }

    // Function that updates health bar and text
    void UpdateHealth()
    {
        float scaleScaler = (float)GameManager.CurrentSnakeHealth / GameManager.MaxSnakeHealth;
        float newXScale = startingScale.x * scaleScaler;

        healthBar.transform.localScale = new Vector2(newXScale, startingScale.y);
        healthBar.transform.position = new Vector2(startingPosition.x - (startingScale.x - newXScale) / 2f, startingPosition.y);

        if (healthNumberText != null)
        { 
            healthNumberText.text = GameManager.CurrentSnakeHealth.ToString() + "/" + GameManager.MaxSnakeHealth.ToString();
        }
    }
}
