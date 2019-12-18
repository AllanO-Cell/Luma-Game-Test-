using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script has not been made into a scriptable object since it will never need to remember the players stats. The stats will reset everytime the game is run
/// </summary>
public class PlayerStats
{
    [Header("Player Stats")]
    public int
        playerStartingHealth,
        currentPlayerHealth,
        playerAttackDamage,
        playerAttackSpeed,
        playerMoveSpeed,
        playerTurnSpeed;

}



public class Player
{
    // for the damage controls and such
}






