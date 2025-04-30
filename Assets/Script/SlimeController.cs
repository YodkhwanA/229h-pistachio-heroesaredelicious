using UnityEngine;

public class SlimeController : MonoBehaviour
{


    public float speed = 5f;
    public float jumpForce = 200f;
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

        // กระโดดแบบฟิสิกส์ ใช้ AddForce เฉพาะตอนอยู่บนพื้น
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // แตะพื้น
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        // ชนมอนสเตอร์
        if (other.gameObject.CompareTag("Monster"))
        {
            // ถ้ากระโดดลงใส่มอน (ความเร็วแกน Y ต้องเป็นลบ)
            if (rb2d.velocity.y < 0)
            {
                Monster monster = other.gameObject.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.Die(); // มอนตาย
                }

                // เด้งกลับขึ้นหลังเหยียบ
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2f);
                isJumping = true;
            }
            else
            {
                // โดนมอนจากด้านข้าง = อาจจะโดนตีหรือตาย (ถ้ามีระบบนี้)
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

