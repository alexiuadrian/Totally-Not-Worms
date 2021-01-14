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
            Game_Manager.isDead[1] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Soldier") {
            Game_Manager.isDead[2] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Demoman") {
            Game_Manager.isDead[3] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Heavy") {
            Game_Manager.isDead[4] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Sniper") {
            Game_Manager.isDead[5] = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Captain") {
            Game_Manager.isDead[6] = true;
            Destroy(other.gameObject);
        }
    }
}
