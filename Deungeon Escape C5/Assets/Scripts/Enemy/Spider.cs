using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
  
    public int Health { get; set; }
    // Use for initialization
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        
    }
    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Health--;
       if (Health < 1)
        {
            anim.SetTrigger("Death");
            GameObject diamond = (GameObject)Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().gems = base.gems;
            Destroy(this.gameObject, 1.0f);
        }
    }

    public override void Movement()
    {
       // sit still
    }

    public void Attack()
    {
      
                Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
