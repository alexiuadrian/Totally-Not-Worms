using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierHitRegister : MonoBehaviour
{
    public int health = 30;
    
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Soldier: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Soldier: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Soldier is dead!";
            Game_Manager.isDead[2] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 3;
            ScoreManager.instance.TakeDamage(3, 3);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 5;
            ScoreManager.instance.TakeDamage(3, 5);
            Destroy(other.gameObject);
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 6;
            ScoreManager.instance.TakeDamage(3, 6);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 5;
            ScoreManager.instance.TakeDamage(3, 5);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 6;
            ScoreManager.instance.TakeDamage(3, 6);
            Destroy(other.gameObject);
        }	
    }

    public void Dead() 
    {
        healthText.text = "Soldier is dead!";
    }

     public void Penalty() {
        health -= 5;
        ScoreManager.instance.TakeDamage(3, 5);
    }
}
