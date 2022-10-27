using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currHP;
    public int maxHP;
    public EnemyMovement movController;
    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }
    public void ApplyDamage(int dmg)
    {
        currHP -= dmg;
        _anim.SetTrigger("Damage");
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
