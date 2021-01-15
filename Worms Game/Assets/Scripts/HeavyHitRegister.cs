using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyHitRegister : MonoBehaviour
{
    public static int health = 30;
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
            healthText.text = "Heavy: 0";
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

    public static int GetHealth()
    {
        return health;
    }
}
