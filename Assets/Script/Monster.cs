using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float speed;
    public int damage;
    

    protected Transform baseTarget;
    public Rigidbody2D rb;
    public GameObject territory;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        territory = GameObject.FindGameObjectWithTag("Base");
    }
    public void Die()
    {
        Destroy(gameObject); 
    }
    public void Update()
    {
         Vector2 d= (territory.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(d.x  * speed, rb.velocity.y);
        if (d.x < 0)
            transform.localScale = new Vector3(-5f, 5f, 5f); 
        else if (d.x > 0)
            transform.localScale = new Vector3(5f, 5f, 5f);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
           

           
            Base baseScript = other.gameObject.GetComponent<Base>();
            if (baseScript != null)
            {
                baseScript.TakeDamage(damage);
            }

           
            Die();
        }
    }

}

