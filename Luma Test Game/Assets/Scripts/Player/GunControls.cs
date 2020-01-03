using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour
{
    Character_Movement movement;
    PlayerStats m_playerStats;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;

    float shootRateTimeStamp;

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
        if (movement.isRunning)
        {
            FireGun();
        }
        else
            return;
    }



    /// <summary>
    /// Gathering information on whats been hit using raycasts and dealing damage according to the players stats
    /// </summary>
    private void FireGun()
    {

        if (Time.time > shootRateTimeStamp)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
            shootRateTimeStamp = Time.time + m_playerStats.playerAttackSpeed;
        }

        //if (Physics.Raycast(ray, out hit, 100))
        //{
        //    var enemyHealth = hit.collider.GetComponent<Enemy>(); // gets the enemy script on the AI to reduce the health
        //    if (enemyHealth != null)
        //        enemyHealth.TakeDamage(m_playerStats.playerAttackDamage); // deals the damage based on the player stats
        //}


    }


}
