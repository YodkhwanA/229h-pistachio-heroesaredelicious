using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOverSreen GameOverSreen;
    public void GameOver()
    {
        GameOverSreen.Setup();
    }
}
