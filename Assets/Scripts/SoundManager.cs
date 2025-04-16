//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, float volume){

        //assign audio clip

        //assign volume

        //play sound

        //get length of fx clip
    }


}