using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public float speed;
    public int damage;
    

    protected Transform baseTarget;

    
   
    public void Die()
    {
        Destroy(gameObject); // ������ Object Pooling ᷹�����
    }




}

