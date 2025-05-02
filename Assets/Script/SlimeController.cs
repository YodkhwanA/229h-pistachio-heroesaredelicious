using UnityEngine;

using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpTime = 0.8f; 
    public bool isJumping = false;

    private float moveInput;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            float direction = moveInput >= 0 ? 1f : -1f;

            Vector2 origin = rb2d.position;

            
            Vector2 target = origin + new Vector2(3f * direction, 2f);

            Vector2 jumpVelocity = CalculateProjectileVelocity(origin, target, jumpTime);
            rb2d.velocity = jumpVelocity;
            isJumping = true;
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
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



