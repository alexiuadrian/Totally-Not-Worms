using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{

    public int scoutHealth, sniperHealth, demomanHealth, heavyHealth, captainHealth, soldierHealth;
    //public int team1Hp, team2Hp;
    //public static int top1Hp = 2, top2Hp = 0, top3Hp = 0;

    public float[] scoutPosition = new float[3];
    public float[] sniperPosition = new float[3];
    public float[] demomanPosition = new float[3];
    public float[] heavyPosition = new float[3];
    public float[] captainPosition = new float[3];
    public float[] soldierPosition = new float[3];
    public int turn;

    public string[,] map = new string[150, 50];

    public SaveData()
    {
        GameObject scout = GameObject.Find("Characters[A]/Scout");
        GameObject sniper = GameObject.Find("Characters[A]/Sniper");
        GameObject demoman = GameObject.Find("Characters[A]/Demoman");
        GameObject heavy = GameObject.Find("Characters[A]/Heavy");
        GameObject captain = GameObject.Find("Characters[A]/Captain");
        GameObject soldier = GameObject.Find("Characters[A]/Soldier");

        scoutHealth = ScoutHitRegister.GetHealth();
        sniperHealth = SniperHitRegister.GetHealth();
        demomanHealth = DemomanHitRegister.GetHealth();
        heavyHealth = HeavyHitRegister.GetHealth();
        captainHealth = CaptainHitRegister.GetHealth();
        soldierHealth = SoldierHitRegister.GetHealth();

        //team1Hp = scoutHealth + sniperHealth + demomanHealth;
        //team2Hp = heavyHealth + captainHealth + soldierHealth;

        //if (team1Hp == 0)
        //{
        //    if (SaveData.top1Hp < team2Hp)
        //    {
        //        SaveData.top3Hp = SaveData.top2Hp;
        //        SaveData.top2Hp = SaveData.top1Hp;

        //        SaveData.top1Hp = team2Hp;
        //    }
        //    else if (SaveData.top2Hp < team2Hp)
        //    {
        //        SaveData.top3Hp = SaveData.top2Hp;
        //        SaveData.top2Hp = team2Hp;
        //    }
        //    else if (SaveData.top3Hp < team2Hp)
        //    {
        //        SaveData.top3Hp = team2Hp;
        //    }
        //}

        //if (team2Hp == 0)
        //{
        //    if (SaveData.top1Hp < team1Hp)
        //    {
        //        SaveData.top3Hp = SaveData.top2Hp;
        //        SaveData.top2Hp = SaveData.top1Hp;

        //        SaveData.top1Hp = team1Hp;
        //    }
        //    else if (SaveData.top2Hp < team1Hp)
        //    {
        //        SaveData.top3Hp = SaveData.top2Hp;

        //        SaveData.top2Hp = team1Hp;
        //    }
        //    else if (SaveData.top3Hp < team1Hp)
        //    {
        //        SaveData.top3Hp = team1Hp;
        //    }
        //}

        gatherTerrainData();
        gatherCharactersData();
    }


    public void gatherCharactersData()
    {
        GameObject scout = GameObject.Find("Characters[A]/Scout");
        GameObject sniper = GameObject.Find("Characters[A]/Sniper");
        GameObject demoman = GameObject.Find("Characters[A]/Demoman");
        GameObject heavy = GameObject.Find("Characters[A]/Heavy");
        GameObject captain = GameObject.Find("Characters[A]/Captain");
        GameObject soldier = GameObject.Find("Characters[A]/Soldier");

        scoutHealth = ScoutHitRegister.GetHealth();
        scoutPosition[0] = scout.transform.position.x;
        scoutPosition[1] = scout.transform.position.y;
        scoutPosition[2] = scout.transform.position.z;

        sniperHealth = SniperHitRegister.GetHealth();
        sniperPosition[0] = sniper.transform.position.x;
        sniperPosition[1] = sniper.transform.position.y;
        sniperPosition[2] = sniper.transform.position.z;

        demomanHealth = DemomanHitRegister.GetHealth();
        demomanPosition[0] = demoman.transform.position.x;
        demomanPosition[1] = demoman.transform.position.y;
        demomanPosition[2] = demoman.transform.position.z;

        heavyHealth = HeavyHitRegister.GetHealth();
        heavyPosition[0] = heavy.transform.position.x;
        heavyPosition[1] = heavy.transform.position.y;
        heavyPosition[2] = heavy.transform.position.z;

        captainHealth = CaptainHitRegister.GetHealth();
        captainPosition[0] = captain.transform.position.x;
        captainPosition[1] = captain.transform.position.y;
        captainPosition[2] = captain.transform.position.z;

        soldierHealth = SoldierHitRegister.GetHealth();
        soldierPosition[0] = soldier.transform.position.x;
        soldierPosition[1] = soldier.transform.position.y;
        soldierPosition[2] = soldier.transform.position.z;

        turn = Game_Manager.GetTurn();
        Debug.Log("Am salvat cand este tura lui " + turn.ToString());
    }

    public void gatherTerrainData()
    {
        var stoneList = GameObject.FindGameObjectsWithTag("Stone");
        var dirtList = GameObject.FindGameObjectsWithTag("Dirt");
        var grassList = GameObject.FindGameObjectsWithTag("Grass");
        var waterList = GameObject.FindGameObjectsWithTag("Water");

        foreach (var elem in stoneList)
        {
            map[(int)elem.transform.position.x, (int)elem.transform.position.y] = "stone";
        }
        foreach (var elem in dirtList)
        {
            map[(int)elem.transform.position.x, (int)elem.transform.position.y] = "dirt";

        }
        foreach (var elem in grassList)
        {
            map[(int)elem.transform.position.x, (int)elem.transform.position.y] = "grass";
        }

    }
}
