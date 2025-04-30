using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float speed;
    public int damage;
    

    protected Transform baseTarget;

    
   
    public void Die()
    {
        Destroy(gameObject); // หรือใช้ Object Pooling แทนถ้ามี
    }




}

