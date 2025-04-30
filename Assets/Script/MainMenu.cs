using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void MainMenuPlayGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
