using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Enemy Stats", menuName = "Enemy")]
public class EnemyStatsSO : ScriptableObject
{
    // ** note need parameter for ranged or melee this will most likely be another scriptable object

    public int
        enemyStartingHealth,
        //enemyCurrentHealth,
        enemyAttackSpeed,
        enemyAttackDamage,
        enemyMoveSpeed;

    public bool isRanged;
        
}
