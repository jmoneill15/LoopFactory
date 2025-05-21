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
    public void LoadGame()
    {
        Debug.Log("Game Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(1); //Changes it to the first screen in the scenes hierarchy

    }

    //Load Exit Screen 
    public void LoadExitScreen()
    {
        Debug.Log("Exit Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(2); //Changes it to exit screen

    }

    //Load Title Screen
    public void LoadTitleScreen()
    {
        Debug.Log("Title Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(0); //Changes it to exit screen

    }

    //Load tutorial
    public void LoadTutorialScreen()
    {
        Debug.Log("Tutorial intro Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(4); //Changes it to exit screen

    }

    //
    public void LoadTutMovementScreen()
    {
        Debug.Log("Tutorial movement Screen Loaded");
        SceneManager.LoadScene(5);
    }

    //
    public void LoadTutObjectiveScreen()
    {
        Debug.Log("Tutorial objective Screen Loaded");
        SceneManager.LoadScene(6);
    }

    public void LoadTutWhileLoopScreen()
    {
        Debug.Log("Tutorial while loop Screen Loaded");
        SceneManager.LoadScene(7);
    }

    public void LoadTutKeyDetailsScreen()
    {
        Debug.Log("Tutorial Key Details Screen Loaded");
        SceneManager.LoadScene(8);
    }
    public void LoadTutForLoopScreen()
    {
        Debug.Log("Tutorial for loop Screen Loaded");
        SceneManager.LoadScene(9);
    }

    public void LoadTutPlayGameScreen()
    {
        Debug.Log("Tutorial for loop Screen Loaded");
        SceneManager.LoadScene(10);
    }

}