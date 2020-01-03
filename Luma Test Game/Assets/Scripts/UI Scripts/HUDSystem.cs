using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Since this is a simple UI system it will not be necesaary complicate it and rather just update the values displayed as they show from the player stats
/// </summary>
public class HUDSystem : MonoBehaviour
{
    public Image currentHealth;
    public Image levelUpBar;
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

        levelUpBar.fillAmount = 0;
    }

    public void UpdateHud()
    {
        levelUpBar.fillAmount = Map(stats.experience, 0, 100, 0, 1);
        currentLevel.text = stats.level.ToString();
        currentHealth.fillAmount = Map(player.currentHealth, 0, 100, 0, 1); 
    }

    public float Map(float value, float inMin, float inMax, float outMin, float outmax)
    {
        return (value - inMin) * (outmax - outMin) / (inMax - inMin) + outMin;
    }
}
