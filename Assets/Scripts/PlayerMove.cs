using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 9f;
    private float jumpingPower = 8f;
    private bool isFacingRight= true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) // this checks if nova is on the ground 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)  // this checks if nova is in the air
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate() //this allows nova to dash foward depending on which way that she is loooking
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift)
            ? sprintSpeed
            : walkSpeed;

        rb.linearVelocity = new Vector2(
            horizontal * currentSpeed,
            rb.linearVelocity.y
        );
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        }
    
    }

    
}
