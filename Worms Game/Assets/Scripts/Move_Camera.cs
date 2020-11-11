using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move_Camera : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float move_x = 0f;
        float move_y = 0f;
        if (Input.GetAxisRaw("Mouse X") > -20 && Input.GetAxisRaw("Mouse X") < 20)
        {
            move_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed;
            if (Input.GetAxisRaw("Mouse Y") > 0)
            {
                move_y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed;
            }
        }
        */
        
        transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0f);

    }
}
