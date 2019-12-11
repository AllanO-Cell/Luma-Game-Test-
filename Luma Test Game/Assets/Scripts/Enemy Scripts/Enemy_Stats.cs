using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script serves as the scriptable object for the stats needed for the enemy AI this will store all the stats and will be read by another script at run time 
/// </summary>


[CreateAssetMenu(fileName = "Enemy stats", menuName = "Enemy")]
public class Enemy_Stats : ScriptableObject
{
    [Range(5f, 10f)]
    public int startingHealth;


    public int damageAmount;
    

    
}
