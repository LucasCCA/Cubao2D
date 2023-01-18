using UnityEngine;

public class Obstacle : MonoBehaviour
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
        //transform.position += Vector3.left * gm.obstacleVelocity * Time.deltaTime;
        Vector2 direction = new(-gm.obstacleVelocity * Time.deltaTime, 0);
        rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
