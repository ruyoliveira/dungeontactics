using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBattleHandler : MonoBehaviour
{
    public GridManager currentGrid;
    public GenPlayerInput _input;
    public Card[] cards;
    public Card selectedCard;
    public PlayerTileMovement playerTileMovement;
    public int currCard;

    // Card art
    public GameObject[] cardHUD;

    // Delay used to inputs and temporary disabling movement
    public float delay = 1f;
    private float timer;

    private void Awake()
    {
        //_input = GetComponent<GenPlayerInput>();
        currCard = 0;
        timer = 0;
        NextCardRandom();
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

        if (timer <= delay)
            timer += Time.deltaTime;
    }
    private bool IsOnCooldown()
    {
        return timer <= delay ? true : false;
    }
    private void SetCooldown()
    {
        timer = 0;
    }

    public Card NextCardOrdered()
    {
        if(currCard < cards.Length-1)
        {
            currCard++;
        }
        else
        {
            currCard = 0;
        }
        return cards[currCard];
    }

    public Card NextCardRandom()
    {
        currCard = Random.Range(0, cards.Length);
        UpdateCardHUD(cards[currCard].id);
        return cards[currCard];
    }
    private void UpdateCardHUD(int id)
    {
        foreach(GameObject obj in cardHUD)
        {
            obj.SetActive(false);
        }
        if(id < cardHUD.Length)
        {
            Debug.Log("Card ID: " + id);
            cardHUD[id].SetActive(true);
        }
    }
    public void OnAction1()
    {
        Debug.Log("Action1");
        if(! IsOnCooldown())
        {
            // Temporary disable movement
            playerTileMovement.DisableMovement(1.0f);
            foreach (Vector2 target in cards[currCard].targets)
            {
                Tile selTile = currentGrid.SelectTile(target + playerTileMovement.currTileId);
                if (selTile != null)
                {
                    selTile.SetTimedEffect(EffectType.Damage, 1.0f, 0.3f);
                    SetCooldown();
                }
            }
            NextCardRandom();

            
        }
        
    }
  

}
