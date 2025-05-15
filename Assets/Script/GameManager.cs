using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverSreen GameOverSreen;
    public AudioClip GameOverSfx;
    public AudioSource audioSource;
    public AudioClip bgSfx;

    private int currentLevel;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSfx;
        audioSource.loop = true;
        audioSource.Play();

        
        currentLevel = SaveSystem.LoadLevel();
        Debug.Log("‚À≈¥¥Ë“π≈Ë“ ÿ¥: " + currentLevel);
    }

    
    public void OnLevelComplete()
    {
        currentLevel++;
        SaveSystem.SaveLevel(currentLevel);
        SceneManager.LoadScene("Level" + currentLevel);
    }

   
    public void LoadSavedLevel()
    {
        int savedLevel = SaveSystem.LoadLevel();
        SceneManager.LoadScene("Level" + savedLevel);
    }

    public void GameOver()
    {
        GameOverSreen.Setup();
        audioSource.Stop();
        audioSource.PlayOneShot(GameOverSfx);
    }
}