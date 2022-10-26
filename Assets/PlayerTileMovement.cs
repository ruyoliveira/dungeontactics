using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerTileMovement : MonoBehaviour
{
    public GridManager currentGrid;
    // Player position offset insider the tile
    public Vector3 posOffset;

    [SerializeField]
    private Vector2 movVector;
    // Delay between inputs
    public float inputDelay;
    public float timer;
    public Vector2 currTileId;


    // Start is called before the first frame update
    public void PrepareBattle()
    {
        // Player start position
        transform.position = currentGrid.GetTile(currentGrid.startPos).transform.position + posOffset;
        currTileId = currentGrid.startPos;
        timer = inputDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= inputDelay)
        {
            timer = 0;
            if (movVector.x > 0)
            {
                Debug.Log("Right");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.right);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.right;
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;

                }
            }
            else if (movVector.x < 0)
            {
                Debug.Log("Left");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.left);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.left;
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                }
            }

            else if (movVector.y > 0)
            {

                Debug.Log("Up");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.up);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.up;
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                }

            }
            else if (movVector.y < 0)
            {
                Debug.Log("Down");
                // Check if tile  is walkable or exists
                GameObject newTileObj = currentGrid.GetTile(currTileId + Vector2.down);
                if (newTileObj != null)
                {
                    // Update current tile id
                    currTileId += Vector2.down;
                    // Update player position
                    transform.position = newTileObj.transform.position + posOffset;
                }
            }
        }
        else
            timer += Time.deltaTime;
        
    }
    private void OnMove(InputValue movementValue)
    {
        movVector = movementValue.Get<Vector2>();

    }
}
