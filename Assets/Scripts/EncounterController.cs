using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    public Player player;
    public Enemy[] enemies;
    public Vector2[] enemiesSpawnPoints;
    public GridManager grid;
    // Gets lower number of items between spawnpoins and enemies
    //public int nEnemies;
    // Start is called before the first frame update
    public void PrepareBattle()
    {
        // Add grid ref for all enemies
        for(int i = 0; i < enemies.Length; i++)
        {

            enemies[i].gameObject.SetActive(true);
            enemies[i].movController.currentGrid = grid;
            enemies[i].movController.PrepareBattle(enemiesSpawnPoints[i]);
        }
        player.battlerHandler.currentGrid = grid;
        player.tileMovement.currentGrid = grid;
        player.tileMovement.PrepareBattle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
