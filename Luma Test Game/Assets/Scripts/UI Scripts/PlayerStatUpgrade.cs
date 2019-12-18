using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this script will control the updates for the stat screen and update the players stats
/// </summary>
public class PlayerStatUpgrade : MonoBehaviour
{
    public int upgradePoints = 1;

    public PlayerStats stats;

    public Button
        health,
        attkSpeed,
        attkDamage,
        moveSpeed;



    #region StatUpgrades

    //public void UpgradeHealth(bool upgradeable)
    //{
    //    if (upgradePoints != 0) upgradeable = true;
    //    else
    //        return;

    //    if (upgradeable = true)
    //        currentPlayerHealth += 10;

    //    upgradeable = false;
    //}

    public void UpgradeAttackSpeed(bool upgradeable)
    {
        if (upgradePoints != 0) upgradeable = true;
        else
            return;

        if (upgradeable = true)
            stats.playerAttackSpeed += 10;

        upgradeable = false;
    }


    //public void UpgradeAttackDmg(bool upgradeable)
    //{
    //    if (upgradePoints != 0) upgradeable = true;
    //    else
    //        return;

    //    if (upgradeable = true)
    //        playerAttackDamage += 10;

    //    upgradeable = false;
    //}

    //public void UpgradeMoveSpeed(bool upgradeable)
    //{
    //    if (upgradePoints != 0) upgradeable = true;
    //    else
    //        return;

    //    if (upgradeable = true)
    //    {
    //        playerMoveSpeed += 10;
    //        playerTurnSpeed += 10;

    //    }

    //    upgradeable = false;
    //}
    #endregion


}
