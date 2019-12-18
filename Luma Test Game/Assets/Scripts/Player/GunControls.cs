using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : PlayerStats
{
    Character_Movement movement;

    float timer;
    public Transform firePoint;


    /// <summary>
    /// Checks if the player is running. if it is then the player will fire. if not the player will not fire
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= playerAttackSpeed)
        {
            if (movement.isRunning)
            {
                timer = 0;
                FireGun();
            }
            else
                return;
        }
    }



    /// <summary>
    /// Gathering information on whats been hit using raycasts and dealing damage according to the players stats
    /// </summary>
    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            var enemyHealth = hit.collider.GetComponent<Enemy>(); // gets the enemy script on the AI to reduce the health
            if (enemyHealth != null)
                enemyHealth.TakeDamage(playerAttackDamage); // deals the damage based on the player stats
        }
    }
}
