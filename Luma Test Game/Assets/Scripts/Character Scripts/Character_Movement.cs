using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character_Movement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed;

    public bool running;

    // caching the character controller on awake
    void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }


    /// <summary>
    /// reading the iput from the input settings in order to move the character.
    /// This uses the character controller Unity comes with
    /// </summary>
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);


        //Based off the speed the game is running at and the set move speed
        characterController.SimpleMove(movement * Time.deltaTime);
    }

}
