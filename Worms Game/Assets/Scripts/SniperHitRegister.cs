using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperHitRegister : MonoBehaviour
{
    public static int health = 30;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Sniper: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Sniper: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Sniper: 0";
            Game_Manager.isDead[4] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoutBullet")
        {
            health -= 4;
        }
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 6;
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 7;
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 6;
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 8;
        }	
    }

    public static int GetHealth()
    {
        return health;
    }
}
