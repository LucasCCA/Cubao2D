using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new(-gm.coinVelocity * Time.deltaTime, 0);
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount", 0) + 1);
            Destroy(gameObject);
        }
    }
}
