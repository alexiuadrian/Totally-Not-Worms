using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Gaymanager : MonoBehaviour
{
    public GameObject Character1 = null;
    public GameObject Character2 = null;
    public GameObject Character3 = null;
    public GameObject Character4 = null;
    public GameObject Character5 = null;
    public GameObject Character6 = null;
    public int nr = 0;
    public int seconds = 0;

    float timer = 0.0f;
    float prevTime = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        Turn(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        prevTime += Time.deltaTime;
        seconds = (int) (timer % 60);

        if (Input.GetKeyUp(KeyCode.T))
        {
            nr++;
            if (nr == 7)
            {
                nr = 1;
            }
            Turn(false);
            prevTime = 0.005f;
        }
        else if (prevTime % 40 < 0.005)
        {
            //Turn(nr, true);

            //Console.Write("1");
            //Delay(5);
            //Console.Write("2");
            nr++;
            if (nr == 7)
            {
                nr = 1;
            }
            Turn(false);
            prevTime = 0.005f;
        }
    }

    public void Turn(bool penalty)
    {
        string Good = "Activate";
        if (penalty)
        {
            Good = "Penalty";
        }
        
        string Bad = "Deactivate";

        switch (nr)
        {
            case 1:
                {
                    Character1.gameObject.SendMessage(Good);
                    Character2.gameObject.SendMessage(Bad);
                    Character3.gameObject.SendMessage(Bad);
                    Character4.gameObject.SendMessage(Bad);
                    Character5.gameObject.SendMessage(Bad);
                    Character6.gameObject.SendMessage(Bad);
                    break;
                }
            case 2:
                {
                    Character2.gameObject.SendMessage(Good);
                    Character1.gameObject.SendMessage(Bad);
                    Character3.gameObject.SendMessage(Bad);
                    Character4.gameObject.SendMessage(Bad);
                    Character5.gameObject.SendMessage(Bad);
                    Character6.gameObject.SendMessage(Bad);
                    break;
                }
            case 3:
                {
                    Character3.gameObject.SendMessage(Good);
                    Character2.gameObject.SendMessage(Bad);
                    Character1.gameObject.SendMessage(Bad);
                    Character4.gameObject.SendMessage(Bad);
                    Character5.gameObject.SendMessage(Bad);
                    Character6.gameObject.SendMessage(Bad);
                    break;
                }
            case 4:
                {
                    Character4.gameObject.SendMessage(Good);
                    Character2.gameObject.SendMessage(Bad);
                    Character3.gameObject.SendMessage(Bad);
                    Character1.gameObject.SendMessage(Bad);
                    Character5.gameObject.SendMessage(Bad);
                    Character6.gameObject.SendMessage(Bad);
                    break;
                }
            case 5:
                {
                    Character5.gameObject.SendMessage(Good);
                    Character2.gameObject.SendMessage(Bad);
                    Character3.gameObject.SendMessage(Bad);
                    Character4.gameObject.SendMessage(Bad);
                    Character1.gameObject.SendMessage(Bad);
                    Character6.gameObject.SendMessage(Bad);
                    break;
                }
            case 6:
                {
                    Character6.gameObject.SendMessage(Good);
                    Character2.gameObject.SendMessage(Bad);
                    Character3.gameObject.SendMessage(Bad);
                    Character4.gameObject.SendMessage(Bad);
                    Character5.gameObject.SendMessage(Bad);
                    Character1.gameObject.SendMessage(Bad);
                    break;
                }
            default:
                {
                    nr = 1;
                    break;
                }
        }
    }

    public void Delay(int seconds)
    {
        System.Threading.Thread.Sleep(seconds * 1000);
    }
}
