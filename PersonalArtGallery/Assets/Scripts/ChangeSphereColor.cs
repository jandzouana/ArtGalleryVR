using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSphereColor : MonoBehaviour {
    private Material originalColor;
    public Material newColor;
    public ButtonInteract buttonScript;
    public SceneUtilities utilitiesScript;
    private bool changedColor;
    private bool canTrigger;


	// Use this for initialization
	void Start () {
        originalColor = gameObject.GetComponent<Renderer>().material;
        changedColor = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (buttonScript.on && buttonScript.switchTrigger) { 
            gameObject.GetComponent<Renderer>().material = originalColor;
            gameObject.GetComponent<AudioSource>().Stop();
            changedColor = false;
        }
        else if (buttonScript.switchTrigger)
        {
            gameObject.GetComponent<Renderer>().material = newColor;
            utilitiesScript.StopAllAudio();
            gameObject.GetComponent<AudioSource>().Play();
            changedColor = true;
        }
    }
}
