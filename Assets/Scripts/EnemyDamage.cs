
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody2D playerRb =
            collision.gameObject.GetComponent<Rigidbody2D>();

        PlayerHealth playerHealth =
            collision.gameObject.GetComponent<PlayerHealth>();

        if (playerRb == null || playerHealth == null)
            return;

        // Ignore damage when Nova lands on top.
        bool stomped = false;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y < -0.5f &&
                playerRb.linearVelocity.y <= 0f)
            {
                stomped = true;
                break;
            }
        }

        if (stomped)
            return;

        // Damage Nova on side or bottom collisions.
        playerHealth.TakeDamage(damage);
    }
}
