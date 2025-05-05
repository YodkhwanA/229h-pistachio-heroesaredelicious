using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonPlay : MonoBehaviour 
{

    private void Start()
    {
        
    }
    public void PlayGame()
    {
        
        SceneManager.LoadSceneAsync(1);
        
    }

    public void QuitGame()
    {
       

        Application.Quit();
    }
   
}
