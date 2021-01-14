﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyHitRegister : MonoBehaviour
{
    public int health = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Game_Manager.isDead[5] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 2;
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 4;
        }	
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 5;
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 4;
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 6;
        }	
    }
}
