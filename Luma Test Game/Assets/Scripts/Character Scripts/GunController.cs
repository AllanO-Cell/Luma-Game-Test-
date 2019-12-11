using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Character_Movement moveScript;
    public PlayerStats playerStats;

    //rate of fire to be increased as per level and random drops
    [SerializeField]
    [Range (0.5f, 1.5f)]
    float fireRate = 1;


    // damage to be increased as per level and random drops
    [SerializeField]
    [Range(1f, 10f)]
    int damage = 1;

    private float timer;

    public Transform firePoint;

    /// <summary>
    /// caching the script so that we can read the bool to see if the character is moving or not
    /// this is to be used so that we can fire while moving and stop firing when the player is not moving
    /// </summary>
    private void Awake()
    {
        if (!moveScript)
            moveScript = FindObjectOfType<Character_Movement>();

        if (!playerStats)
            playerStats = FindObjectOfType<PlayerStats>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (moveScript.isRunning)
                timer = 0;
            FireGun();
        }
    }


    /// <summary>
    /// <see cref="Ray"/> dray ray is used to test the raycast being used to fire
    /// <seealso cref="RaycastHit"/> this is being used to gather information on what has been hit
    /// </summary>
    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        // Checking to see if we hit anything and fill hitInfo with the object that we hit 
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Enemy>(); // gets the enemy component on the enemy to reduce the health
            if (health != null)
                health.TakeDamage(playerStats.playerDamage);   // deals the damage based on the damage from the player stats
        }


    }
}
