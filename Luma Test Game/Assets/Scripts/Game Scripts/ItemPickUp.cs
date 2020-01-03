using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Notes*******
// Need to create the items and instantiate them the same way we randomly spawn enemies
//

public class ItemPickUp : MonoBehaviour
{
    public bool
         healthItem,
         dmgItem,
         attkSpeedItem,
         msItem;

    int percent;
    public GameObject m_particles;


    HUDSystem healthUpdate;
    Player playerHealth;
    PlayerStats currentStats;

    private void OnEnable()
    {
        playerHealth = FindObjectOfType<Player>();
        currentStats = FindObjectOfType<PlayerStats>();
        healthUpdate = FindObjectOfType<HUDSystem>();
    }




    /// <summary>
    /// on trigger enter checks which item it is and call the appropriate function 
    /// destroys the 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (healthItem)
            {
                percent = (int)UnityEngine.Random.Range(20f, 50f);
                AddHealth(playerHealth.currentHealth);
                healthUpdate.UpdateHud();
                

            }

        if (dmgItem)
        {
            StartCoroutine(currentStats.DamageBoost());
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(m_particles);
            Destroy(gameObject, 11f);
        }


        if (attkSpeedItem)
        {
            StartCoroutine(currentStats.AttackSpeedBoost());
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(m_particles);
            Destroy(gameObject, 11f);
        }

        if (msItem)
        {
            StartCoroutine(currentStats.MoveSpeedBoost());
            Destroy(gameObject.GetComponent<Collider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(m_particles);
            Destroy(gameObject, 11f);
        }

    }

    /// <summary>
    /// Random percentaage is selected. Adds the percetage of the players current health to the current health
    /// </summary>
    /// <param name="health"></param> pass in the players current health
    void AddHealth(int health)
    {
        float total = ((float)percent / 100) * health;
        playerHealth.currentHealth = playerHealth.currentHealth + (int)Math.Ceiling(total);
        Destroy(gameObject, 2f);
    }





}
