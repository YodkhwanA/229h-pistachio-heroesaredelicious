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
        Debug.Log("Direction.x = " + d.x);
    }




}

