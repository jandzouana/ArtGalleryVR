using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class StreamVideo : MonoBehaviour {

    public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;
	
	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")) StartCoroutine(playVideo());
	}
	void OnTriggerExit(Collider col){
		if(col.CompareTag("Player")) StartCoroutine(pauseVideo());
	}
    // Use this for initialization
	void Start () {
		StartCoroutine(prepareVideo());
	}

	IEnumerator stopVideo(){
		 audioSource.Pause();
		 videoPlayer.Stop();
		 yield return null;
	}
	IEnumerator pauseVideo(){
		 audioSource.Pause();
		 videoPlayer.Pause();
		 yield return null;
	}
	IEnumerator prepareVideo(){
		//Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
		//We want to play from video clip not from url  
        videoPlayer.source = VideoSource.VideoClip;
		//Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();
        Application.runInBackground = true;
		

        // Vide clip from Url
        //videoPlayer.source = VideoSource.Url;
        //videoPlayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
		//Set Audio Output to AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
		videoPlayer.isLooping = true;
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        Debug.Log("Done Preparing Video");
		//Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;
	}
    IEnumerator playVideo()
    {
        //Play Video
        videoPlayer.Play();

        //Play Sound
        audioSource.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        Debug.Log("Done Playing Video");
		yield return null;
    }

    // Update is called once per frame
    void Update () {
		
	}
}