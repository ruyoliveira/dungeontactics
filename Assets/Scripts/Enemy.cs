using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currHP;
    public int maxHP;
    public EnemyMovement movController;
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
            this.gameObject.SetActive(false);
        }
    }
}
