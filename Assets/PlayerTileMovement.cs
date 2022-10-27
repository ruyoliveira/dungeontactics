using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerTileMovement : MonoBehaviour
{
    public Player _player;
    public GridManager currentGrid;
    public Vector2 spawnPoint;
    // Player position offset insider the tile
    public Vector3 posOffset;

    [SerializeField]
    private Vector2 movVector;
    public float inputDelay;
    // Delay used to inputs and temporary disabling movement
    private float delay;
    private float timer;
    // On delay
    public bool isOnDelay = false;
    public Vector2 currTileId;
    private Tile currentTile;

    // Damage checking once
    public bool hasDamaged;


    // Start is called before the first frame update
    public void PrepareBattle()
    {
        // Player start position
        transform.position = currentGrid.GetTile(currentGrid.startTile).transform.position + posOffset;
        currTileId = currentGrid.startTile;
        timer = delay;
    }
    private void BeginDelay(float time)
    {
        timer = 0;
        delay = time;
        isOnDelay = true;
    }
    private void EndDelay()
    {
        isOnDelay = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= delay)
        {
            EndDelay();
            if (movVector.x > 0)
            {
                BeginDelay(inputDelay);
                Debug.Log("Right");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.right);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.right;
                    // Update current tile
                    currentTile = currentGrid.SelectTile(currTileId);
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                    hasDamaged = false;

                }

            }
            else if (movVector.x < 0)
            {
                BeginDelay(inputDelay);
                Debug.Log("Left");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.left);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.left;
                    // Update current tile
                    currentTile = currentGrid.SelectTile(currTileId);
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                    hasDamaged = false;

                }
            }

            else if (movVector.y > 0)
            {
                BeginDelay(inputDelay);
                Debug.Log("Up");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.up);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.up;
                    // Update current tile
                    currentTile = currentGrid.SelectTile(currTileId);
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                    hasDamaged = false;

                }

            }
            else if (movVector.y < 0)
            {
                BeginDelay(inputDelay);
                Debug.Log("Down");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.down);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.down;
                    // Update current tile
                    currentTile = currentGrid.SelectTile(currTileId);
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                    hasDamaged = false;

                }
            }
        }
        else
            timer += Time.deltaTime;

        if (currentTile != null)
        {
            if (!hasDamaged && CheckDamageTile())
            {
                hasDamaged = true;
                _player.ApplyDamage(1);
            }
        }

    }
    private void OnMove(InputValue movementValue)
    {
        movVector = movementValue.Get<Vector2>();

    }

    // Disable movement using delay and timer
    public void DisableMovement(float time)
    {
        delay = time;
        timer = 0;
    }

    private bool CheckDamageTile()
    {
        return currentTile.GetEffect() == EffectType.Damage;
    }
}
