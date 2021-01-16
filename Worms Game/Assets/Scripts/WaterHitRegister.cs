using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHitRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Scout") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(0, 30);
            Game_Manager.isDead[1] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Soldier") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(3, 30);
            Game_Manager.isDead[2] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Demoman") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(2, 30);
            Game_Manager.isDead[3] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Heavy") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(4, 30);
            Game_Manager.isDead[4] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Sniper") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(1, 30);
            Game_Manager.isDead[5] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Captain") {
            other.gameObject.SendMessage("Dead");
            ScoreManager.instance.TakeDamage(5, 30);
            Game_Manager.isDead[6] = true;
            Destroy(other.gameObject);
        }
    }
}
