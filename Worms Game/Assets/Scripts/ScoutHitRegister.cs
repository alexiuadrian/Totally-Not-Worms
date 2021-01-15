using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoutHitRegister : MonoBehaviour
{
    public static int health = 30;
    
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
            healthText.text = "Scout: 0";
            Game_Manager.isDead[1] = true;
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DemomanBullet")
        {
            health -= 8;
        }
        if (other.gameObject.tag == "SniperBullet")
        {
            health -= 10;
        }	
        if (other.gameObject.tag == "HeavyBullet")
        {
            health -= 8;
        }
        if (other.gameObject.tag == "CaptainBullet")
        {
            health -= 6;
        }
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 11;
        }
    }

    public static int GetHealth()
    {
        return health;
    }
}
