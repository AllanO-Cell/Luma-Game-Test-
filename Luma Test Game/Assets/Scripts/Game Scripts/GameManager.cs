using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Stat Changes")]
    public GameObject lvlCanvas;
    public EnemyStatsSO[] statUpdate;
    public Animator attackAnimation;

    public bool lvlInProgress;
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnTime; // will change every level
    public Transform[] spawnLocations;
    public List<GameObject> registeredEnemies = new List<GameObject>();

    int enemyAmount = 3; //initial amount of enemies will change as levels go higher

    public int playerScore;
    


    /// <summary>
    /// repeat invokes the spawn function based on the time
    /// Calls a function on the enemy scriptable objects to reset the default stats
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InvokeRepeating("SpawnEnemies", 0, spawnTime);

    }


    /// <summary>
    /// The update method checks if we have reached maximum amount of enemies and cancles the invoke - stops the spawning
    /// We also check if we have no enemies registered and if the level is supposed to be inprogress if we dont we end the round
    /// </summary>
    private void Update()
    {

        if (registeredEnemies.Count == enemyAmount)
        {
            CancelInvoke();
        }

        if (registeredEnemies.Count == 0 && lvlInProgress == true)
        {
            lvlInProgress = false;
            RoundOver();

        }
    }






    /// <summary>
    /// Spawn function. Time will be set and increased after every level completion. Amount of enemies to spawn will be determined by the "enemyAmount" value which will update after every level
    /// checking to see if the level has ended if it hasnt carry on spawning if it has stop the repeating invoke
    /// </summary>
    void SpawnEnemies()
    {
        if (lvlInProgress = false)
        {
            CancelInvoke();
            return;
        }
        lvlInProgress = true;
        int spawnPointIndex = Random.Range(0, spawnLocations.Length);
        GameObject newGo = Instantiate(enemies[Random.RandomRange(0, enemies.Count)], spawnLocations[spawnPointIndex].position, spawnLocations[spawnPointIndex].rotation);
        registeredEnemies.Add(newGo);

    }



    /// <summary>
    /// prepares the next round of enimies with upgrades to their stats
    /// Resets the players health back to what the value was before the previous round started
    /// </summary>
    void RoundOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        FindObjectOfType<Player>().RefreshHealth();
        lvlCanvas.SetActive(true);
        while (lvlInProgress == false)
        {

            foreach (EnemyStatsSO stat in statUpdate)
            {
                stat.enemyStartingHealth += 10;
                stat.enemyAttackSpeed += 0.1f;
                stat.enemyAttackDamage += 10;
                stat.enemyMoveSpeed += 1;
                stat.DeathXp += 10;
            }
            attackAnimation.speed += 0.5f;
            // adding a random amount of enemies after the first level based on the current amount 
            int additionalEnemies = Random.Range(enemyAmount, enemyAmount += 3);
            enemyAmount = +additionalEnemies;
            Time.timeScale = 0;
            break;
        }

    }


    /// <summary>
    /// called when the UI button to continue is pressed
    /// </summary>
    public void StartNextRound()
    {
        Time.timeScale = 1;
        lvlCanvas.SetActive(false);
        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    /// <summary>
    /// resetting the stats for the enemies and reloading the level giving a fresh start to the game
    /// </summary>
    public void RestartGame()
    {
        foreach (EnemyStatsSO stats in statUpdate)
        {
            stats.ResetDefaultStats();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    /// <summary>
    /// whenever the game is quit we reset the enemy stats to default
    /// Called from the High score UI
    /// </summary>
    void OnApplicationQuit()
    {
        foreach (EnemyStatsSO stats in statUpdate)
        {
            stats.ResetDefaultStats();
        }
    }


}

