using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCalibrator : MonoBehaviour
{

    public GameObject LeftHand;
    public GameObject LeftHandAvatar;

    // Use this for initialization
    void Start()
    {
        if (LeftHand == null)
            LeftHand = GameObject.Find("LeftHandAnchor");
            if (LeftHandAvatar == null)
                LeftHandAvatar = transform.FindChild("hand_left").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += LeftHand.transform.position - LeftHandAvatar.transform.position;
    }
}