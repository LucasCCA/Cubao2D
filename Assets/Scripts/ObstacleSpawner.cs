using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Configuration")]
    [SerializeField]
    private float spawnRate = 2f;
    [SerializeField]
    private float spawnOffset = 2f;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject groundObstacle;

    [SerializeField]
    private GameObject flyingObstacle;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnRate);
    }

    void SpawnObstacle()
    {
        float number = Random.value;
        Vector3 flyingOffset = new(0, spawnOffset, 0);

        if (number <= 0.3)
        {
            Instantiate(flyingObstacle, transform.position + flyingOffset, transform.rotation);
        }
        else
        {
            Instantiate(groundObstacle, transform.position, transform.rotation);
        }
    }
}
