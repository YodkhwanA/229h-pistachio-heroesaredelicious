using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;

    public float desiredJumpHeight = 4f;         // ความสูงที่อยากให้กระโดดได้
    public float gravity = 9.8f;                 // ค่าคงที่แรงโน้มถ่วง
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

        // เคลื่อนที่ซ้าย-ขวา
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        // คำนวณความเร็วที่ต้องใช้เพื่อกระโดดให้ได้ความสูงที่กำหนด
        float jumpSpeed = Mathf.Sqrt(2 * gravity * desiredJumpHeight);

        // กระโดดแบบฟิสิกส์ ใช้ velocity แทน AddForce เพื่อควบคุมแม่นยำ
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
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
                    monster.Die(); // มอนตาย
                }

                // เด้งกลับหลังเหยียบ
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2f);
                isJumping = true;
            }
            else
            {
                Debug.Log("โดนมอนตี!");
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


