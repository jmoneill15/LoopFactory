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
    public AudioClip endGameLose;
    public AudioClip endGameWin;
    public AudioClip point;

    //Once game starts music is playing constantly
    private void Start() 
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    //Helper function to allow for me to add SFX to all the files I need to
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
    
}
