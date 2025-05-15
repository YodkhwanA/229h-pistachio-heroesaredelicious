using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        SaveData data = SaveSystem.Load();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = i + 1;
            bool unlocked = level <= data.UnlockedLevel;

            levelButtons[i].interactable = unlocked;

            if (unlocked)
            {
                int sceneIndex = level; 
                levelButtons[i].onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("Level" + level);
                });
            }
        }
    }
}