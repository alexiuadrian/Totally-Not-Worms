using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject Character1 = null;
    public GameObject Character2 = null;
    public GameObject Character3 = null;
    public GameObject Character4 = null;
    public GameObject Character5 = null;
    public GameObject Character6 = null;
    public static List<bool> isDead = new List<bool>();
    public static int nr = 0;
    public int seconds = 0;
    public Text currentTeam;
    public Text timeLeft;

    float timer = 0.0f;
    public float prevTime = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= 10; i++) {
            isDead.Add(false);
        }
        currentTeam.text = "Press 'T' to start!";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        prevTime += Time.deltaTime;
        seconds = (int) (timer % 60);
        bool ok = false;
        timeLeft.text = "Time left: " + (40 - ((int) prevTime % 60)).ToString();
        if (Input.GetKeyUp(KeyCode.T))
        {
            nr++;
            if (nr >= 7)
            {
                nr = 1;
            }
            while (isDead[nr])
            {
                nr++;
            }
            Turn(false);
            prevTime = 0.005f;
        }
        else if (prevTime % 40 < 0.005)
        {
            Turn(true);
            nr++;
            if (nr >= 7)
            {
                nr = 1;
            }
            while (isDead[nr])
            {
                nr++;
            }
            Turn(false);
            prevTime = 0.005f;
        }
        else {

            if(nr % 2 == 1) {
                currentTeam.text = "Team 1 is playing!";
            }
            else if(nr != 0){
                currentTeam.text = "Team 2 is playing!";
            }

            if(isDead[1] && isDead[3] && isDead[5]) 
            {
                SceneManager.LoadScene("WinTeam2");
            }

            if(isDead[2] && isDead[4] && isDead[6]) 
            {
                SceneManager.LoadScene("WinTeam1");
            }

            if (isDead[nr])
            {
                ok = true;
            }
            
            if(ok)
            {
                nr++;
                if (nr >= 7)
                {
                    nr = 1;
                }
                while (isDead[nr])
                {
                    nr++;
                }
                ok = false;
                Turn(false);
            }
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
                    if(isDead[1]) {
                        nr++;
                    }
                    else {
                        Character1.gameObject.SendMessage(Good);
                    }
                    if(!isDead[2]) {
                        Character2.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[3]) {
                        Character3.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[4]) {
                        Character4.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[5]) {
                        Character5.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[6]) {
                        Character6.gameObject.SendMessage(Bad);
                    }
                    break;
                }
            case 2:
                {
                    if(isDead[2]) {
                        nr++;
                    }
                    else {
                        Character2.gameObject.SendMessage(Good);
                    }
                    if(!isDead[1]) {
                        Character1.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[3]) {
                        Character3.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[4]) {
                        Character4.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[5]) {
                        Character5.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[6]) {
                        Character6.gameObject.SendMessage(Bad);
                    }
                    break;
                }
            case 3:
                {
                    if(isDead[3]) {
                        nr++;
                    }
                    else {
                        Character3.gameObject.SendMessage(Good);
                    }
                    if(!isDead[2]) {
                        Character2.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[1]) {
                        Character1.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[4]) {
                        Character4.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[5]) {
                        Character5.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[6]) {
                        Character6.gameObject.SendMessage(Bad);
                    }
                    break;
                }
            case 4:
                {
                    if(isDead[4]) {
                        nr++;
                    }
                    else {
                        Character4.gameObject.SendMessage(Good);
                    }
                    if(!isDead[2]) {
                        Character2.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[3]) {
                        Character3.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[1]) {
                        Character1.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[5]) {
                        Character5.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[6]) {
                        Character6.gameObject.SendMessage(Bad);
                    }
                    break;
                }
            case 5:
                {
                    if(isDead[5]) {
                        nr++;
                    }
                    else {
                        Character5.gameObject.SendMessage(Good);
                    }
                    if(!isDead[2]) {
                        Character2.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[3]) {
                        Character3.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[4]) {
                        Character4.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[1]) {
                        Character1.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[6]) {
                        Character6.gameObject.SendMessage(Bad);
                    }
                    break;
                }
            case 6:
                {
                    if(isDead[6]) {
                        nr++;
                    }
                    else {
                        Character6.gameObject.SendMessage(Good);
                    }
                    if(!isDead[2]) {
                        Character2.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[3]) {
                        Character3.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[4]) {
                        Character4.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[5]) {
                        Character5.gameObject.SendMessage(Bad);
                    }
                    if(!isDead[1]) {
                        Character1.gameObject.SendMessage(Bad);
                    }
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
