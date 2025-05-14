using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject enemyPrefab;

    
    public int waveCount = 3;
    public float spawnDelay = 4f;
    public float startDelay = 3f;
    public int nextSceneIndex = 2;

    
    public TMP_Text waveText; 
    public GameObject endPanel; 

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
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < waveCount; i++)
        {
            
            if (waveText != null)
                waveText.text = $"Wave {i + 1} / {waveCount}";

            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }

        
        if (endPanel != null)
            endPanel.SetActive(true);

        yield return new WaitForSeconds(2f); 

        SceneManager.LoadSceneAsync(nextSceneIndex);
    }
}