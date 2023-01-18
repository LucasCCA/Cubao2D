using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    public int highScore;

    [SerializeField]
    private TMP_Text highScoreText;

    private GameManager gm;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        scoreText.text = gm.obstacleCount.ToString("0");
        highScoreText.text = highScore.ToString("0");
    }
}
