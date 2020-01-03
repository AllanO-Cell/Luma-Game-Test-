using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Since this is a simple UI system it will not be necesaary complicate it and rather just update the values displayed as they show from the player stats
/// </summary>
public class HUDSystem : MonoBehaviour
{
    public Slider currentHealth;
    public Slider levelUpBar;
    public Text currentLevel;

    PlayerStats stats;
    Player player;

    /// <summary>
    /// caching the stats on awake
    /// </summary>
    private void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<Player>();
    }

    public void UpdateHud()
    {
        levelUpBar.value = stats.experience;
        currentLevel.text = stats.level.ToString();
        currentHealth.value = player.currentHealth;
    }
}
