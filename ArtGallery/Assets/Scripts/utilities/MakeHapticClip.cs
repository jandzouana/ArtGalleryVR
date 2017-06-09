using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MakeHapticClip : MonoBehaviour {
 
    [SerializeField] private AudioClip audio;
    const int channel = 1;
    OVRHapticsClip HapticClip;
 
    // Use this for initialization
    void Start () {
 
        // Make Haptic Clip:
        HapticClip = new OVRHapticsClip(audio, channel);
 
        // Play Haptic Clip:
        Debug.Log("play haptics");
        OVRHaptics.RightChannel.Preempt (HapticClip);
        OVRHaptics.LeftChannel.Preempt (HapticClip);
    }
}
 