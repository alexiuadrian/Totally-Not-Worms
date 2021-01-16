using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoutHitRegister : MonoBehaviour
{
    public int health = 30;
    
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Scout: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Scout: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Scout is dead!";
            Game_Manager.isDead[1] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 8;
            ScoreManager.instance.TakeDamage(0, 8);
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 10;
            ScoreManager.instance.TakeDamage(0, 10);
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 8;
            ScoreManager.instance.TakeDamage(0, 8);
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 6;
            ScoreManager.instance.TakeDamage(0, 6);
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 11;
            ScoreManager.instance.TakeDamage(0, 11);
        }	
    }

    public void Dead() 
    {
        healthText.text = "Scout is dead!";
    }

    public void Penalty() {
        health -= 5;
        ScoreManager.instance.TakeDamage(0, 5);
    }
}
