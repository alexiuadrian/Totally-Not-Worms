using UnityEngine;
using UnityEngine.UI;

public class SaveEachTeamScore : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Scorul obtinut: " + GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScore()
    {
        int score = PlayerPrefs.GetInt("Score");

        return score;
    }
}
