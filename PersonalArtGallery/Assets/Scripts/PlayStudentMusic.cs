using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStudentMusic : MonoBehaviour {
    public ButtonInteract buttonScript;
    public SceneUtilities utilitiesScript;
    public GameObject music;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonScript.on && buttonScript.switchTrigger)
        {
            music.GetComponent<AudioSource>().Stop();
        }
        else if (buttonScript.switchTrigger)
        {
            utilitiesScript.StopAllAudio();
            music.GetComponent<AudioSource>().Play();
        }
    }
}
