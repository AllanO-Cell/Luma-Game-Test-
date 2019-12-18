using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour
{
    Character_Movement movement;
    PlayerStats m_playerStats;

    float timer;
    public Transform firePoint;


    private void Awake()
    {
        movement = FindObjectOfType<Character_Movement>();
        m_playerStats = FindObjectOfType<PlayerStats>();
    }

    /// <summary>
    /// Checks if the player is running. if it is then the player will fire. if not the player will not fire
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= m_playerStats.playerAttackSpeed)
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
                enemyHealth.TakeDamage(m_playerStats.playerAttackDamage); // deals the damage based on the player stats
        }
    }


}
