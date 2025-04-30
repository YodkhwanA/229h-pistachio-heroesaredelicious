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

        // ����͹������-���
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        // ���ⴴẺ���ԡ�� �� AddForce ੾�е͹���躹���
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // �о��
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

        // ���͹�����
        if (other.gameObject.CompareTag("Monster"))
        {
            // ��ҡ��ⴴŧ����͹ (��������᡹ Y ��ͧ��ź)
            if (rb2d.velocity.y < 0)
            {
                Monster monster = other.gameObject.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.Die(); // �͹���
                }

                // �駡�Ѻ�����ѧ����º
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2f);
                isJumping = true;
            }
            else
            {
                // ⴹ�͹�ҡ��ҹ��ҧ = �Ҩ��ⴹ�����͵�� (������к����)
                Debug.Log("ⴹ�͹��!");
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

