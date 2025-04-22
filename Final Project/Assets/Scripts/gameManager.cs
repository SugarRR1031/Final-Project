using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    //public PlayerMovement myPlayer; no longer needed, we change the score differently now
    private int score = 0;

    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI scoreDisplay;

    public float endTime = 15.0f;

    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.txt";
    string PATH_HIGH_SCORE;

    public const string PREF_HIGH_SCORE = "hsScore";

    public int Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
