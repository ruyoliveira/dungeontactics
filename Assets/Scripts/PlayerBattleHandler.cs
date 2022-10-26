using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBattleHandler : MonoBehaviour
{
    public GridManager currentGrid;
    public GenPlayerInput _input;
    public Card selectedCard;
    public PlayerTileMovement playerTileMovement;
    private void Awake()
    {
        //_input = GetComponent<GenPlayerInput>();
    }
    private void OnEnable()
    {
        //_input.Enable();
    }
    private void OnDisable()
    {
        //_input.Disable();
    }

    private void Update()
    {
        
        /*
        if(Keyboard.current.jKey.wasPressedThisFrame)
        {
            Debug.Log("Action1");
            // Use selected card
            
        }
        */
        

    }
    public void OnAction1()
    {
        Debug.Log("Action1");

        if (selectedCard)
        {
            foreach (Vector2 target in selectedCard.targets)
            {
                currentGrid.SelectTile(target + playerTileMovement.currTileId);
            }
        }
    }
    
    
}
