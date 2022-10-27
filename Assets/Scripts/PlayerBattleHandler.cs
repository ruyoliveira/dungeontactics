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


    }
    public void OnAction1()
    {
        Debug.Log("Action1");

        if (selectedCard)
        {
            // Temporary disable movement
            playerTileMovement.DisableMovement(1.0f);
            foreach (Vector2 target in selectedCard.targets)
            {
                currentGrid.SelectTile(target + playerTileMovement.currTileId).SetTimedEffect(EffectType.Damage,1.0f, 0.3f);
            }
        }
    }
    
    
}
