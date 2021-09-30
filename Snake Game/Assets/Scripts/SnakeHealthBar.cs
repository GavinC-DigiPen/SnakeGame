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
    public GameObject healthBar;
    public TextMeshProUGUI healthNumberText;

    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null && healthNumberText != null)
        {
            UpdateHealth();
            GameManager.OnHealthChange.AddListener(UpdateHealth);
        }
    }

    // Function that updates health bar and text
    void UpdateHealth()
    {
        healthBar.transform.localScale = new Vector2(1, 1);

        healthNumberText.text = GameManager.CurrentSnakeHealth.ToString() + "/" + GameManager.MaxSnakeHealth.ToString();
    }
}
