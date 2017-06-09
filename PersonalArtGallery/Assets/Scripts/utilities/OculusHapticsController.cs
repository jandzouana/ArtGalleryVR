using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusHapticsController : MonoBehaviour
{

	public enum VibrationForce
	{
        Slight,
		Light,
		Medium,
		Hard,
	}
	[SerializeField]
	OVRInput.Controller controllerMask;

    private OVRHapticsClip clipSlight;
    private OVRHapticsClip clipLight;
	private OVRHapticsClip clipMedium;
	private OVRHapticsClip clipHard;

	private void Start()
	{
		InitializeOVRHaptics();
	}

	private void InitializeOVRHaptics()
	{
		int cnt = 10;
        clipSlight = new OVRHapticsClip(cnt);
        clipLight = new OVRHapticsClip(cnt);
		clipMedium = new OVRHapticsClip(cnt);
		clipHard = new OVRHapticsClip(cnt);
		for (int i = 0; i < cnt; i++)
		{
            clipSlight.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)35;
            clipLight.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)75;
			clipMedium.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)150;
			clipHard.Samples[i] = i % 2 == 0 ? (byte)0 : (byte)255;
		}

        clipSlight = new OVRHapticsClip(clipSlight.Samples, clipSlight.Samples.Length);
        clipLight = new OVRHapticsClip(clipLight.Samples, clipLight.Samples.Length);
		clipMedium = new OVRHapticsClip(clipMedium.Samples, clipMedium.Samples.Length);
		clipHard = new OVRHapticsClip(clipHard.Samples, clipHard.Samples.Length);
	}

	public void Vibrate(VibrationForce vibrationForce)
	{
		var channel = OVRHaptics.RightChannel;
		if (controllerMask == OVRInput.Controller.LTouch)
			channel = OVRHaptics.LeftChannel;

		switch (vibrationForce)
		{
            case VibrationForce.Slight:
                channel.Preempt(clipSlight);
                break;
            case VibrationForce.Light:
				channel.Preempt(clipLight);
				break;
			case VibrationForce.Medium:
				channel.Preempt(clipMedium);
				break;
			case VibrationForce.Hard:
				channel.Preempt(clipHard);
				break;
		}
	}


    [SerializeField]
	OculusHapticsController leftControllerHaptics;

	[SerializeField]
	OculusHapticsController rightControllerHaptics;

    //Creates a haptic feedback to one controller ranging from force 0-3 (Slight to Hard)
    //To be used in other scripts
    public void SimpleVibrate(string controller, int force)
    {
        if (controller == "left")
        {
            switch (force)
            {
                case 0:
                    leftControllerHaptics.Vibrate(VibrationForce.Slight);
                    break;
                case 1:
                    leftControllerHaptics.Vibrate(VibrationForce.Light);
                    break;
                case 2:
                    leftControllerHaptics.Vibrate(VibrationForce.Medium);
                    break;
                case 3:
                    leftControllerHaptics.Vibrate(VibrationForce.Hard);
                    break;
                default:
                    leftControllerHaptics.Vibrate(VibrationForce.Slight);
                    break;
            }
        }
        if (controller == "right")
        {
            switch (force)
            {
                case 0:
                    rightControllerHaptics.Vibrate(VibrationForce.Slight);
                    break;
                case 1:
                    rightControllerHaptics.Vibrate(VibrationForce.Light);
                    break;
                case 2:
                    rightControllerHaptics.Vibrate(VibrationForce.Medium);
                    break;
                case 3:
                    rightControllerHaptics.Vibrate(VibrationForce.Hard);
                    break;
                default:
                    rightControllerHaptics.Vibrate(VibrationForce.Slight);
                    break;
            }
        }
    }

}