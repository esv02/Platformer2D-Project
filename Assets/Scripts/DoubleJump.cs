using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public int extraJumpsValue = 1;
    private int extraJumps;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // normal jump
            } 
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // extra jump
                extraJumps--;
            }
        }
    }
}
