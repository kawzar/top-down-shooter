using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            var bullet = collision.GetComponent<Bullet>();
            bullet.Die();
        }
    }
}
