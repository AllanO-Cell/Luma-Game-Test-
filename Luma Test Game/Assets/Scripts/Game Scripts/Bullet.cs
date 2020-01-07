using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }


    /// <summary>
    /// Comparing the tag. If it matches we check if the health is null if not then we tell the enemy to take damage based on the player damage stats
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemyHealth = other.GetComponent<Enemy>();
            if(enemyHealth != null)
            {
                var damageToTake = FindObjectOfType<PlayerStats>();
                enemyHealth.TakeDamage(damageToTake.playerAttackDamage);
            }
        }
    }
}
