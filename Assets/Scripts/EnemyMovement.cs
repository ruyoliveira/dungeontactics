using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public MovementPattern pattern;
    public int patternStep;
    public Vector2 startPos;

    // Grid reference
    public GridManager currentGrid;
    // Player position offset insider the tile
    public Vector3 posOffset;
    // Input delay
    public float inputDelay;
    private float delay;
    private float timer;
    public Vector2 currTileId;



    // Start is called before the first frame update
    void Start()
    {
        PrepareBattle();

    }

    public void PrepareBattle()
    {
        // Start position
        transform.position = currentGrid.GetTile(currentGrid.startPos).transform.position + posOffset;
        currTileId = startPos;
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
                // Try to get target tile from grid
                GameObject newTileObj = currentGrid.GetTile(currTileId + pattern.targets[patternStep]);
                // Check if tile  is walkable or exists
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += pattern.targets[patternStep];
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                }
            }
            // Cycle steps in boundaries
            patternStep = patternStep < pattern.targets.Length - 1? patternStep+1: patternStep = 0;
        }

   
        else
            timer += Time.deltaTime;
    }
}
