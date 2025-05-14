using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public float startDelay = 2f;       
        public float spawnDelay = 0.5f;     
        public int[] enemyInx;          
    }

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public Wave[] waves;

    public TMP_Text countdownText;
    public TMP_Text waveText;
    public GameObject endPanel;
    public Button buttonSelectStage;
    public Button buttonNextStage;

    void Start()
    {
        if (waveText != null)
            waveText.text = "Wave 1";
        StartCoroutine(CountdownThenStart());
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            Wave currentWave = waves[i];

           
            if (waveText != null)
            {
                waveText.gameObject.SetActive(true);
                waveText.text = $"Wave {i + 1} / {waves.Length}";
            }

            yield return new WaitForSeconds(currentWave.startDelay);

            foreach (int enemyIndex in currentWave.enemyInx)
            {
                Spawn(enemyIndex);
                yield return new WaitForSeconds(currentWave.spawnDelay);
            }

            yield return new WaitForSeconds(2f); 
        }

        
        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }

        yield return new WaitForSeconds(3f);
        EndLevel();
        
    }
    IEnumerator CountdownThenStart()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true);

            countdownText.text = "3";
            yield return new WaitForSeconds(1f);

            countdownText.text = "2";
            yield return new WaitForSeconds(1f);

            countdownText.text = "1";
            yield return new WaitForSeconds(1f);

            countdownText.text = "Start!";
            yield return new WaitForSeconds(0.5f);

            countdownText.gameObject.SetActive(false);
        }
        StartCoroutine(SpawnRoutine());
    }

    void Spawn(int enemyIndex)
    {
        if (enemyIndex < 0 || enemyIndex >= enemyPrefabs.Length) return;

        int spawnIdx = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIdx].position, Quaternion.identity);
    }
    void EndLevel()
    {
        if (endPanel != null)
            endPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void OnSelectStageButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageScene"); 
    }

    public void OnNextStageButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}