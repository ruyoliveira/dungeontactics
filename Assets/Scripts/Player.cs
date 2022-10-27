using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currHP;
    public int maxHP;
    public PlayerBattleHandler battlerHandler;
    public PlayerTileMovement tileMovement;
    public PlayerControl controls;
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP <=0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
