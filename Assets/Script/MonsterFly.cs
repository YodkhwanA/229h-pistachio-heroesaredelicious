using UnityEngine;

public class MonsterFly : Monster
{
    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        territory = GameObject.FindGameObjectWithTag("Base");
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
        speed = 5f;  
        damage = 10f; 
    }

    private void Update()
    {

        Vector2 direction = (territory.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;


        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (direction.x < 0 ? -1 : 1);
        transform.localScale = scale;

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
        else if (other.gameObject.CompareTag("Player"))
        {
            
            Die();
        }
    }
}
   

