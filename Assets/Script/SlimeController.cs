using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;

    public float desiredJumpHeight = 4f;         // �����٧�����ҡ�����ⴴ��
    public float gravity = 9.8f;                 // ��Ҥ�����ç�����ǧ
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

        // �ӹǳ�������Ƿ���ͧ�����͡��ⴴ���������٧����˹�
        float jumpSpeed = Mathf.Sqrt(2 * gravity * desiredJumpHeight);

        // ���ⴴẺ���ԡ�� �� velocity ᷹ AddForce ���ͤǺ��������
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
                    monster.Die(); // �͹���
                }

                // �駡�Ѻ��ѧ����º
                rb2d.velocity = new Vector2(rb2d.velocity.x, 2f);
                isJumping = true;
            }
            else
            {
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


