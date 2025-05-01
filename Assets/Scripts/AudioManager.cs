using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source----------------")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("---------Audio Clip----------------")]
    //Area to add specific sound effect moments
    public AudioClip background;
    public AudioClip pickup;
    public AudioClip drop;
    public AudioClip breakLoop;
    public AudioClip endGameLose;
    public AudioClip completeTask;
    public AudioClip loseHeart;

    //Once game starts music is playing constantly
    private void Start() 
    {
        musicSource.clip = background;
        musicSource.volume = 0.1f;  // Turn music down
        SFXSource.volume = 1.0f;    // Max out SFX
        musicSource.Play();
    }

    //Helper function to allow for me to add SFX to all the files I need to
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
    
}
