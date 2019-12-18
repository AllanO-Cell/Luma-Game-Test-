using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This script has not been made into a scriptable object since it will never need to remember the players stats. The stats will reset everytime the game is run
/// </summary>

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    public int
        playerStartingHealth,
        currentPlayerHealth, // move current player health to player script
        playerAttackDamage,
        playerAttackSpeed,
        playerMoveSpeed,
        playerTurnSpeed;

    public float playerExperience; // used for the player to gain xp when killing enemies. some give more some give less
}










