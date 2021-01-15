using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierHitRegister : MonoBehaviour
{
    public static int health = 30;
    
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
            healthText.text = "Soldier: 0";
            Game_Manager.isDead[2] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 3;
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 5;
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 6;
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 5;
        }
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 6;
        }	
    }

    public static int GetHealth()
    {
        return health;
    }
}
