using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This script has not been made into a scriptable object since it will never need to remember the players stats. The stats will reset everytime the game is run
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public int
        playerStartingHealth,
        playerAttackDamage,
        playerMoveSpeed,
        playerTurnSpeed;

    public float playerAttackSpeed;


    public int
        level,
        experience,
        experienceToNextLevel;

    public int upgradePoints; // used to set the players level number



    /// <summary>
    /// adds experience whenever this function is called, mostly on death from the enemy script
    /// </summary>
    /// <param name="xpAmount"></param> Amount of XP to gain parameter, This is based and set from the enemy death script
    public void AddExperience(int xpAmount)
    {

        experience += xpAmount;
        HUDSystem hud = FindObjectOfType<HUDSystem>();
        hud.UpdateHud();
        if (experience >= experienceToNextLevel)
        {
            level++;
            upgradePoints++;
            experience = experienceToNextLevel;
            IncreaseXPNeeded(0, 100 * level * Mathf.Pow(level, 0.5f));
        }
    }


    /// <summary>
    /// increases the amount of experience needed for the character to level up
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="maxValue"></param>
    void IncreaseXPNeeded(float currentValue, float maxValue)
    {
        experienceToNextLevel = (int)currentValue;


    }





    #region IEnumerators for boost
    /// <summary>
    /// Caches the base values of the players stats
    /// boosts the stats for 10 seconds, then resets them to their values before the boost item was picked up
    /// each value is calculated to be "balanced"
    /// </summary>
    /// <returns></returns>
    public IEnumerator DamageBoost()
    {
        int cacheBaseDamage = playerAttackDamage;
        playerAttackDamage = playerAttackDamage * 2;
        yield return new WaitForSecondsRealtime(10f);
        playerAttackDamage = cacheBaseDamage;
    }

    public IEnumerator AttackSpeedBoost()
    {
        float cacheBaseAttkSpeed = playerAttackSpeed;
        playerAttackSpeed = playerAttackSpeed -= 0.2f;
        yield return new WaitForSecondsRealtime(10f);
        playerAttackSpeed = cacheBaseAttkSpeed;
    }

    public IEnumerator MoveSpeedBoost()
    {
        int cacheMS = playerMoveSpeed;
        int cacheTS = playerTurnSpeed;
        playerMoveSpeed += 2;
        playerTurnSpeed += 20;
        yield return new WaitForSecondsRealtime(10f);
        playerMoveSpeed = cacheMS;
        playerTurnSpeed = cacheTS;
    }

    #endregion

}










