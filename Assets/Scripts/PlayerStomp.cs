
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    [SerializeField] private float bounceForce = 8f;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        // Nova must be falling to stomp.
        if (rb.linearVelocity.y > 0f)
            return;

        // Check whether Nova landed on top.
        bool landedOnTop = false;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                landedOnTop = true;
                break;
            }
        }

        if (landedOnTop)
        {
            Destroy(collision.gameObject);

            // Bounce Nova upward.
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                bounceForce
            );
        }
    }
}
