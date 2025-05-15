using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;
    private SaveData saveData;

    private void Start()
    {
        saveData = SaveSystem.Load();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;
            int capturedIndex = levelIndex;

            
            levelButtons[i].interactable = true;

            levelButtons[i].onClick.RemoveAllListeners();
            levelButtons[i].onClick.AddListener(() => TryLoadLevel(capturedIndex));
        }
    }

    void TryLoadLevel(int level)
    {
        if (level == 1)
        {
            
            SceneManager.LoadScene("Level" + level);
        }
        else if (level <= saveData.UnlockedLevel)
        {
            
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            Debug.Log($"Level {level} is locked! Pass previous level first.");
        }
    }
}