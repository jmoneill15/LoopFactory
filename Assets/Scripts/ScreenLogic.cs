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
    
    public void LoadGame(){
        Debug.Log("Game Screen Loaded");
        //titleAudioManager.PlaySFX(titleAudioManager.button);
        SceneManager.LoadScene(1); //Changes it to the first screen in the scenes hierarchy

    }
}
