//in this  script you will find the code for nova to be able to stomp on the player to kill it 
using UnityEngine;

public class PlayerStomp : MonoBehaviour
{
    [SerializeField] private float bounceForce = 8f; //this gives nova the ability to have like a little boost to get to higher airtime after killing the enemy
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))//this is where you can find 
            return;

        // to allow nova to stoomp it only works if she lands on the enemy
        if (rb.linearVelocity.y > 0f)
            return;

        // this  whether Nova landed on top of the enemy .
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

            //this  Bounces Nova upward.
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                bounceForce
            );
        }
    }
}
