using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;

    public float JumpHeight = 4f;         
    public float gravity = 9.8f;                 
    public bool isJumping = false;
    public float jumpAngle = 60f;

    private float moveInput;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);//

        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            float totalJumpSpeed = Mathf.Sqrt(2 * gravity * JumpHeight);

          
            float angleRad = jumpAngle * Mathf.Deg2Rad;
            float jumpVelocityX = totalJumpSpeed * Mathf.Cos(angleRad);
            float jumpVelocityY = totalJumpSpeed * Mathf.Sin(angleRad);

            
            float direction = moveInput >= 0 ? 1f : -1f;

            rb2d.velocity = new Vector2(jumpVelocityX * direction, jumpVelocityY);
            isJumping = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Monster"))
        {
            if (rb2d.velocity.y < 0)
            {
                Monster monster = other.gameObject.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.Die(); 
                }

                
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2f);
                isJumping = true;
            }
            else
            {
                Debug.Log("‚¥π¡Õπµ’!");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}


