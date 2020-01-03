using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }


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
