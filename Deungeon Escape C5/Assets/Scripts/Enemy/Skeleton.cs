﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    // Use for initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
       // Debug.Log("Damage()");
        Health --;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat" , true);

        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = (GameObject)Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
}
