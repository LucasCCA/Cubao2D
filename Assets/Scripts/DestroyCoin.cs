using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
        }
    }
}
