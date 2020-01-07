using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Enemy")]
public class EnemyStatsSO : ScriptableObject
{
    // ** note need parameter for ranged or melee this will most likely be another scriptable object

    public int
        enemyStartingHealth,
        enemyAttackDamage,
        enemyMoveSpeed;

    public float enemyAttackSpeed;

    public bool isRanged;
    public int DeathXp;


    [Header("Deafult Stats")]
    public int defaultHealth;
    public int defaultDamage;
    public int deafaulMoveSpeed;
    public int defaultXp;
    public float defaultAttackSpeed;


    /// <summary>
    /// called whenever the game is quit
    /// restores the stats to their default stats
    /// </summary>
    public void ResetDefaultStats()
    {
        enemyStartingHealth = defaultHealth;
        enemyAttackDamage = defaultDamage;
        enemyMoveSpeed = deafaulMoveSpeed;
        enemyAttackSpeed = defaultAttackSpeed;
        DeathXp = defaultXp;
    }
}
