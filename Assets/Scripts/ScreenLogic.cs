using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 

public class ScreenLogic : MonoBehaviour
{
    
    AudioManager titleAudioManager;

    private void Awake()
    {
        //titleAudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public GameObject titleScreen;
    
    //Load Main Game screen 
    public void LoadGame(){
        Debug.Log("Game Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(1); //Changes it to the first screen in the scenes hierarchy

    }

    //Load Exit Screen 
    public void LoadExitScreen(){
        Debug.Log("Exit Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(2); //Changes it to exit screen

    }

    //Load Title Screen
    public void LoadTitleScreen(){
        Debug.Log("Title Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(0); //Changes it to exit screen

    }

    //Load tutorial
        public void LoadTutorialScreen(){
        Debug.Log("Title Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(3); //Changes it to exit screen

    }
}
