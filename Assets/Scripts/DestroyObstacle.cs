using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            Destroy(collider.gameObject);
            gm.obstacleCount++;

            if (gm.obstacleCount > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", gm.obstacleCount);
                FindObjectOfType<Score>().highScore = PlayerPrefs.GetInt("HighScore", 0);
            }
        }
    }
}
