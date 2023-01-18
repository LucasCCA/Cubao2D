using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawn Configuration")]
    [SerializeField]
    private float spawnRate = 5f;
    [SerializeField]
    private float spawnOffset = 2f;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject coin;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), spawnRate, spawnRate);
    }

    void SpawnCoin()
    {
        float number = Random.value;
        Vector3 offset = new(0, spawnOffset, 0);

        if (number <= 0.3)
        {
            Instantiate(coin, transform.position + offset, transform.rotation);
        }
        else
        {
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
}
