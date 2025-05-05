using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOverSreen GameOverSreen;
    public AudioClip GameOverSfx;
    public AudioSource audioSource;
    public AudioClip bgSfx;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSfx;
        audioSource.loop = true;        
    }

    public void GameOver()
    {
        GameOverSreen.Setup();

        audioSource.Stop();             
        audioSource.PlayOneShot(GameOverSfx); 
    }
}

