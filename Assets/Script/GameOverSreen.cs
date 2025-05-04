using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverSreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }
    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartGameScene");
    }
}

