using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyHitRegister : MonoBehaviour
{
    public int health = 30;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Heavy: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Heavy: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Heavy is dead!";
            Game_Manager.isDead[4] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 2;
            ScoreManager.instance.TakeDamage(4, 2);
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 4;
            ScoreManager.instance.TakeDamage(4, 4);
        }	
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 5;
            ScoreManager.instance.TakeDamage(4, 5);
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 4;
            ScoreManager.instance.TakeDamage(4, 4);
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 6;
            ScoreManager.instance.TakeDamage(4, 6);
        }	
    }

    public void Dead() 
    {
        healthText.text = "Heavy is dead!";
    }

     public void Penalty() {
        health -= 5;
        ScoreManager.instance.TakeDamage(4, 5);
    }
}
