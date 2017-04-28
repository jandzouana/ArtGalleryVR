using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class OvrAvatarHand : MonoBehaviour, IAvatarPart
{

    float alpha = 1.0f;

    public void UpdatePose(OvrAvatarDriver.ControllerPose pose)
    {
	//This will enable collisions only when the hand trigger is pressed enough to make a fist.
		 /*
		 if (GetComponent<Rigidbody>()  != null)
		{
			GetComponent<Rigidbody>().detectCollisions = pose.handTrigger >= 0.75f;
		}
		*/
    }

    public void SetAlpha(float alpha)
    {
        this.alpha = alpha;
    }

    public void OnAssetsLoaded()
    {
        SetAlpha(this.alpha);
    }
}