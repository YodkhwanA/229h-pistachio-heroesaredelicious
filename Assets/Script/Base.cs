using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Base : MonoBehaviour
{
    public float baseHp = 10;
    private Animator animator;
    public float currestHp { get;  private set; }
    public GameManager gameManager;

    private void Awake()
    {
        currestHp = baseHp;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currestHp -= damage;
        currestHp = Mathf.Clamp(currestHp, 0, baseHp);
        animator.SetBool("isHurt", true);
        Invoke(nameof(EndHurt), 1f);


        if (currestHp <= 0)
        {
            gameManager.GameOver();
            Time.timeScale = 0f;
        }
    }

    private void EndHurt()
    {
        animator.SetBool("isHurt", false);
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
