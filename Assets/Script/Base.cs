using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Base : MonoBehaviour
{
    public float baseHp = 10; 
    public float currestHp { get;  private set; }

    private void Awake()
    {
        currestHp = baseHp;
    }
    public void TakeDamage(float damage)
    {
        currestHp -= damage; // ← ลบเลือดก่อน
        currestHp = Mathf.Clamp(currestHp, 0, baseHp); 

        Debug.Log("Base HP: " + currestHp);

        if (currestHp <= 0)
        {
            Debug.Log("แพ้");
            
        }
    }




    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Monster"))
    //    {
    //        baseHp--;

    //        Debug.Log("Base hit! HP left: " + baseHp);

    //        if (baseHp <= 0)
    //        {
    //            Debug.Log("แพ้");
    //        }

    //        Destroy(other.gameObject); // ทำให้มอนตาย
    //    }
    //}
}
