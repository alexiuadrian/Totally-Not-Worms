using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRegister : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ScoutBullet" 
           || other.gameObject.tag == "SoldierBullet"
           || other.gameObject.tag == "DemomanBullet"
           || other.gameObject.tag == "HeavyBullet"
           || other.gameObject.tag == "SniperBullet"
           || other.gameObject.tag == "CaptainBullet") {
            Destroy(gameObject);
        }
    }
}
