using UnityEngine;

using UnityEngine;
using UnityEngine.Audio;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpTime = 0.8f;

    private bool isJumping = false;
    private float moveInput;

    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public AudioClip JumpSfx;
    private AudioSource audioSource;
    public AudioClip dieSfx;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimationStates();
    }

    void HandleMovement()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        
        if (moveInput > 0)
            spriteRenderer.flipX = true;
        else if (moveInput < 0)
            spriteRenderer.flipX = false;
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            float direction = moveInput >= 0 ? 1f : -1f;
            Vector2 origin = rb2d.position;
            Vector2 target = origin + new Vector2(3f * direction, 2f);

            Vector2 jumpVelocity = CalculateProjectileVelocity(origin, target, jumpTime);
            rb2d.velocity = jumpVelocity;
            isJumping = true;
            if (JumpSfx != null && audioSource != null)
            {
                audioSource.PlayOneShot(JumpSfx);
            }

        }
    }

    void UpdateAnimationStates()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb2d.velocity.x));
        animator.SetFloat("yVelocity", rb2d.velocity.y);

        if (isJumping)
        {
            if (rb2d.velocity.y > 0.1f)  
            {
                animator.SetBool("isJumping", true);
            }
            else if (rb2d.velocity.y < -0.1f) 
            {
                animator.SetBool("isJumping", true);
            }
        }
        else
        {
            animator.SetBool("isJumping", false);  
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
            animator.SetBool("isJumping", false);
        }

        if (other.gameObject.CompareTag("Monster") && rb2d.velocity.y < 0)
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            if (monster != null)
                monster.Die();
            audioSource.PlayOneShot(dieSfx);

            rb2d.velocity = new Vector2(rb2d.velocity.x, 4f);
            isJumping = true;
            animator.SetBool("isJumping", true);
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



