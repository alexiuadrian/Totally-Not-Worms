using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemomanHitRegister : MonoBehaviour
{
    public int health = 30;
    
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Demoman: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Demoman: " + health.ToString();
        if (health <= 0)
        {
            healthText.text = "Demoman: 0";
            Game_Manager.isDead[3] = true;
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
        if (other.gameObject.tag == "SoldierBullet")
        {
            health -= 7;
        }
    }
}
