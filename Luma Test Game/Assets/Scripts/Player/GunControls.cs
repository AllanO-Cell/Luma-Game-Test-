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
    /// We instantiate bullets here based on our players attack speed.
    /// Instantiate was used rather than object pooling due to time and amount of code to be written
    /// </summary>
    private void FireGun()
    {

        if (Time.time > shootRateTimeStamp)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
            shootRateTimeStamp = Time.time + m_playerStats.playerAttackSpeed;
        }
    }


}
