using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Enemy _enemy;
    public MovementPattern pattern;
    public int patternStep;

    public Color actionColor;

    // Grid reference
    public GridManager currentGrid;
    // Player position offset insider the tile
    public Vector3 posOffset;
    // Input delay
    public float inputDelay;
    private float delay;
    private float timer;
    public Vector2 currTileId;
    private Tile currentTile;

    // Damage checking once
    public bool hasDamaged;


    public void PrepareBattle(Vector2 spawnTile)
    {
        // Start position
        transform.position = currentGrid.GetTile(spawnTile).transform.position + posOffset;
        currTileId = spawnTile;
        timer = delay;
        patternStep = 0;
        BeginDelay(inputDelay);
    }
    private void BeginDelay(float time)
    {
        timer = 0;
        delay = time;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (timer >= delay)
        {
            BeginDelay(inputDelay);
            // Check type of  next action
            if (pattern.actionType[patternStep] == ActionType.Move)
            {
                Move(patternStep);
            }
            else if (pattern.actionType[patternStep] == ActionType.Damage)
            {
                Attack(patternStep);
            }
            // Cycle steps in boundaries
            patternStep = patternStep < pattern.targets.Length - 1? patternStep+1: patternStep = 0;
        }

   
        else
            timer += Time.deltaTime;
        if(currentTile != null)
        {
            if (!hasDamaged && CheckDamageTile())
            {
                hasDamaged = true;
                _enemy.ApplyDamage(1);
            }
        }
        
    }
    private void Attack(int step)
    {
        // Temporary disable movement
        DisableMovement(1.0f);
        // Try to get target tile from grid
        GameObject newTileObj = currentGrid.GetTile(currTileId + pattern.targets[step]);
        // Check if tile  is walkable or exists
        if (newTileObj != null)
        {
            foreach (Vector2 target in pattern.card.targets)
            {
                Tile selTile = currentGrid.SelectTile(target + currTileId);
                if(selTile != null)
                {
                    selTile.SetTimedEffect(EffectType.Damage, 1.0f, 0.3f, actionColor);
                }
            }
        }
    }
    private void Move(int step)
    {
        // Try to get target tile from grid
        GameObject newTileObj = currentGrid.GetTile(currTileId + pattern.targets[step]);
        // Check if tile  is walkable or exists
        if (newTileObj != null)
        {
            // Update current tile id
            currTileId += pattern.targets[step];
            // Update current tile
            currentTile = currentGrid.SelectTile(currTileId);
            // Update player position
            transform.position = newTileObj.transform.position + posOffset;
            hasDamaged = false;

        }
    }
    private bool CheckDamageTile()
    {
        return currentTile.GetEffect() == EffectType.Damage;
    }
    public void DisableMovement(float time)
    {
        delay = time;
        timer = 0;
    }
}
