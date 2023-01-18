using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [Header("Movement Configuration")]
    [SerializeField]
    private float jumpForce = 300f;

    bool isOnGround = true;

    void FixedUpdate()
    {
        Vector2 direction = new(0, jumpForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(direction, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
