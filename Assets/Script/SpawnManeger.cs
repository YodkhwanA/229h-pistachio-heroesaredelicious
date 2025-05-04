using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManeger : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject enemyPrefab;


     void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Spawn()
    {
        int idx = Random.Range(0, spawnPoint.Length);
        Instantiate(enemyPrefab, spawnPoint[idx].position, Quaternion.identity);
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        Spawn();
        int spawnCount = 0;
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Spawn();
            spawnCount++;
            if (spawnCount >= 10)
            { SceneManager.LoadSceneAsync(2); }



        }


    }
}