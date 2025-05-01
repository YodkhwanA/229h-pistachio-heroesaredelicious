using System.Threading;
using UnityEngine;


public class Base : MonoBehaviour
{
    protected int hp = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            hp--;

            Debug.Log("Base hit! HP left: " + hp);

            if (hp <= 0)
            {
                Debug.Log("แพ้");
            }

            Destroy(other.gameObject); // ทำให้มอนตาย
        }
    }
}
