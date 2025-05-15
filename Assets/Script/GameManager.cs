using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverSreen GameOverSreen;
    public AudioClip GameOverSfx;
    public AudioSource audioSource;
    public AudioClip bgSfx;

    public int currentLevel;

    private SaveData saveData;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSfx;
        audioSource.loop = true;
        audioSource.Play();

        saveData = SaveSystem.Load();

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.StartsWith("Level"))
        {
            string levelNumberString = sceneName.Substring(5); 
            if (int.TryParse(levelNumberString, out int levelNumber))
            {
                currentLevel = levelNumber;
            }
        }
    }

    int GetCurrentLevelFromSceneName()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.StartsWith("Level"))
        {
            string levelNumberStr = sceneName.Substring(5);
            if (int.TryParse(levelNumberStr, out int levelNumber))
                return levelNumber;
        }
        return 1; 
    }

    public void OnLevelComplete()
    {
        if (currentLevel >= saveData.UnlockedLevel)
        {
            saveData.UnlockedLevel = currentLevel + 1;
            SaveSystem.Save(saveData);
            Debug.Log("Level Unlocked! Now: " + saveData.UnlockedLevel);
        }
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOver()
    {
        GameOverSreen.Setup();
        audioSource.Stop();
        audioSource.PlayOneShot(GameOverSfx);
    }
}