using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnmiationEvent : MonoBehaviour
{

    private Spider _spider;
    public void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
      //  Debug.Log("Spider should Fire");
        _spider.Attack();
    }
}
