using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Restart/Exit Configuration")]
    [SerializeField]
    private float restartTime = 2f;

    [SerializeField]
    private string scene;

    [SerializeField]
    private GameObject menu;

    [Header("Obstacle Configuration")]
    public int obstacleCount = 0;

    public float obstacleVelocity = 10f;

    [SerializeField]
    private float velocityUpValue = 1f;

    [SerializeField]
    private float velocityUpTime = 20f;

    [Header("Coin Configuration")]
    public float coinVelocity = 12f;

    void Start()
    {
        InvokeRepeating(nameof(ObstacleSpeedUp), velocityUpTime, velocityUpTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menu.activeSelf)
            {
                FindObjectOfType<SceneLoader>().ChangeScene(scene);
            }
        }
    }

    public void Restart()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        pc.enabled = false;
        Invoke(nameof(Reload), restartTime);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ObstacleSpeedUp()
    {
        obstacleVelocity += velocityUpValue;
    }    
}
