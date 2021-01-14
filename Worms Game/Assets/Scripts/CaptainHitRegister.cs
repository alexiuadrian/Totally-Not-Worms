using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptainHitRegister : MonoBehaviour
{
    public int health = 30;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Captain: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Captain: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Captain is dead!";
            Game_Manager.isDead[6] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 4;
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 6;
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 7;
        }
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 6;
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 8;
        }	
    }

    public void Dead() 
    {
        healthText.text = "Captain is dead!";
    }

     public void Penalty() {
        health -= 5;
    }
}
