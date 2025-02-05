﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character_Movement : MonoBehaviour
{
    CharacterController characterController; // unity character controller
    PlayerStats playerStats;


    public bool isRunning;

    /// <summary>
    /// Caching the character controller
    /// </summary>
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }



    /// <summary>
    /// In the update methode we are controlling the players forward, left, right and backwards movement.
    /// <see cref="isRunning"/> we are checking this if its true or false, this will give us the control for the when the player is firning or not
    /// </summary>
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X");
        var movement = new Vector3(horizontal, 0, vertical);

        characterController.SimpleMove(movement * Time.deltaTime * playerStats.playerMoveSpeed);

        transform.Rotate(Vector3.up, horizontal * playerStats.playerTurnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouseHorizontal * playerStats.playerTurnSpeed * Time.deltaTime);

        if (vertical != 0)
            characterController.SimpleMove(transform.forward * playerStats.playerMoveSpeed * vertical);

        // Check if the player is moving or not
        if (movement.magnitude > 0)
            isRunning = true;
        else
            isRunning = false;

    }
}
