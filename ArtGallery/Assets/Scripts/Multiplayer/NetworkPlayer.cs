using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour {

    public GameObject avatar;

    public Transform playerGlobal;
    public Transform playerLocal;

    void Start()
    {
        Debug.Log("i'm instantiated");
        
        if (photonView.isMine)
        {
            Debug.Log("player is mine");

            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;

            // avatar.SetActive(false);
        }
        
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //sending out info to other players
        if (stream.isWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
        }
        //receiving info from other players
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
