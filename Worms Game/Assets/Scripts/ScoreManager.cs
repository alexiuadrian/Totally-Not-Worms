using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    public int[] charactersHealth = new int[6]; // scout, sniper, demoman, soldier, heavy, captain- prima echipa 0-2
    public int team1score, team2score;
    public int highScore;
    public Text highScoreText;


    public void Awake()
    {
        instance = this;
        team1score = 90;
        team2score = 90;
        for (int i = 0; i < 6; i++)
            charactersHealth[i] = 30;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "Highscore: " + highScore.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int index, int damage)
    {
        if (index < 0 && index > 6)
        {
            Debug.Log("Index has not the correct number");
            return;
        }

        charactersHealth[index] -= damage;

        if (charactersHealth[index] < 0)
        {
            charactersHealth[index] = 0;
        }

        if (index == 0 || index == 1 || index == 2)
        {
            team1score = charactersHealth[0] + charactersHealth[1] + charactersHealth[2];
        }
        else
        {
            team2score = charactersHealth[3] + charactersHealth[4] + charactersHealth[5];
        }
    }

    public void UpdateHighScore()
    {
        int biggerscore;

        if (team1score > team2score)
        {
            biggerscore = team1score;
        }
        else
        {
            biggerscore = team2score;
        }


        if (biggerscore > highScore)
        {
            highScore = biggerscore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "Highscore: " + highScore.ToString();
        }
    }

    public void WriteScores()
    {
        Debug.Log(team1score);
        Debug.Log(team2score);
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
}
