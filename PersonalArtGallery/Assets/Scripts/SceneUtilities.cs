using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUtilities : MonoBehaviour {

    public void StopAllAudio()
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource aud in audios)
        {
            aud.Stop();
        }
    }
}
