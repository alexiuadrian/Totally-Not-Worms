using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData Load()
    {
        string path = Application.persistentDataPath + "/save.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGame()
    {
        Save();
    }

    public static void LoadGame()
    {
        SaveData data = Load();

        GameObject scout = GameObject.Find("Characters[A]/Scout");
        GameObject sniper = GameObject.Find("Characters[A]/Sniper");
        GameObject demoman = GameObject.Find("Characters[A]/Demoman");
        GameObject heavy = GameObject.Find("Characters[A]/Heavy");
        GameObject captain = GameObject.Find("Characters[A]/Captain");
        GameObject soldier = GameObject.Find("Characters[A]/Soldier");

        Vector3 position;

        position.x = data.scoutPosition[0];
        position.y = data.scoutPosition[1];
        position.z = data.scoutPosition[2];
        scout.transform.position = position;

        position.x = data.sniperPosition[0];
        position.y = data.sniperPosition[1];
        position.z = data.sniperPosition[2];
        sniper.transform.position = position;

        position.x = data.demomanPosition[0];
        position.y = data.demomanPosition[1];
        position.z = data.demomanPosition[2];
        demoman.transform.position = position;

        position.x = data.heavyPosition[0];
        position.y = data.heavyPosition[1];
        position.z = data.heavyPosition[2];
        heavy.transform.position = position;

        position.x = data.captainPosition[0];
        position.y = data.captainPosition[1];
        position.z = data.captainPosition[2];
        captain.transform.position = position;

        position.x = data.soldierPosition[0];
        position.y = data.soldierPosition[1];
        position.z = data.soldierPosition[2];
        soldier.transform.position = position;

        Game_Manager.nr = data.turn;


        Debug.Log("Am loadat cand este tura lui " + data.turn.ToString());
        Debug.Log("Dar cu adevarat este tura lui " + Game_Manager.GetTurn().ToString());

    }

}
