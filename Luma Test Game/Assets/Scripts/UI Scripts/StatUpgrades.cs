using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Script for the upgrade stats UI
/// </summary>
public class StatUpgrades : MonoBehaviour
{
    bool canUpgrade;
    public PlayerStats m_stats;
    public Player playerHealth;

    public Text health, damage, attackSpeed, moveSpeed;
    public Button[] uiButtons;
    public Text headerText;


    //cache the player stats once for the whole game
    private void Awake()
    {
        m_stats = FindObjectOfType<PlayerStats>();
        playerHealth = FindObjectOfType<Player>();
    }


    /// <summary>
    ///  Will be called everytime the canvas gameobject is set active since we will only be turning it on and off at the start and end of the round
    ///  Checks if the player has any upgrade points if not disables the interactive option on the button
    ///  
    /// </summary>
    private void OnEnable()
    {
        if (m_stats.upgradePoints != 0)
            canUpgrade = true;

        if(canUpgrade == false)
        {
            foreach (Button b in uiButtons)
            {
                b.interactable = false;
            }

            
        }


    }



    /// <summary>
    /// Updates the UI text with the values from the player stats
    /// </summary>
    private void Update()
    {
        health.text = playerHealth.currentHealth.ToString();
        damage.text = m_stats.playerAttackDamage.ToString();
        attackSpeed.text = m_stats.playerAttackSpeed.ToString();
        moveSpeed.text = m_stats.playerMoveSpeed.ToString();
        if (m_stats.upgradePoints == 0)
        {
            canUpgrade = false;
            headerText.text = "You have no upgrade points to spend";
            headerText.color = Color.red;
        }
        else
        {
            headerText.text = "You have " + m_stats.upgradePoints.ToString() + " points to spend";
            headerText.color = Color.green;
        }
    }




    #region Upgrade system

    /// <summary>
    /// silly way of doing these but each of the stats would need to be updated seperatly
    /// each of these will be assigned to their relative button and the amounts to be added will be assigned there
    /// </summary>
    /// <param name="amount"></param>
    public void UpgradeHealth(int amount)
    {
        if (canUpgrade == true)
            playerHealth.currentHealth = playerHealth.currentHealth + amount;
    }

    public void UpgradeAttkDmg(int amount)
    {
        if (canUpgrade == true)
            m_stats.playerAttackDamage = m_stats.playerAttackDamage + amount;
    }

    public void UpgradeAttackSpeed(float amount)
    {
        if (canUpgrade == true)
            m_stats.playerAttackSpeed = m_stats.playerAttackSpeed - amount;
    }

    public void upgradeMoveSpeed(int amount)
    {
        if (canUpgrade == true)
            m_stats.playerMoveSpeed = m_stats.playerMoveSpeed + amount;
    }

    #endregion
}
