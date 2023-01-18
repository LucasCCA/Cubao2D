using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.Restart();
        }
    }
}
