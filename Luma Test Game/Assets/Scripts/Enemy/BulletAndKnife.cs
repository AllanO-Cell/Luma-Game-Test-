using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAndKnife : MonoBehaviour
{
    public EnemyStatsSO stats;

    /// <summary>
    /// checks if the enemy is ranged, if true the bullet prefab is destroyed after a delay
    /// Not using coroutines as it will take up junk memory
    /// </summary>
    private void Awake()
    {
        if (stats.isRanged == true)
            Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerHealth = other.GetComponent<Player>();
            if(playerHealth != null)
            {
                var damageToTake = stats.enemyAttackDamage;
                playerHealth.TakeDamage(damageToTake);
            }
        }
    }


}
