using UnityEngine;

public class TitleAudioManager : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip titleBackground;

    public AudioClip button;


    //Once game starts music is playing constantly
    private void Start() 
    {
        musicSource.clip = titleBackground;
        musicSource.Play();
    }

    //Helper function to allow for me to add SFX to all the files I need to
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
