using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour {
    public Camera[] Cams;
    int camId = 1;
	// Use this for initialization
	void Start () {
        Invoke("ChangeCam", 10);
        Invoke("ZoomOutCam", .1f);
	}
	void ZoomOutCam()
    {
       // Debug.Log("gfg");
        if (PlayerPrefs.GetInt("Introduction", 0) == 0)
        {
            Invoke("ZoomOutCam", .1f);
            Cams[camId - 1].fieldOfView = Cams[camId - 1].fieldOfView + .1f;
        }
    }
	void ChangeCam()
    {
        if (camId < Cams.Length)
        {
            Cams[camId ].gameObject.SetActive(true); 
            Cams[camId - 1].gameObject.SetActive(false); 
            Invoke("ChangeCam", 10);
            camId = camId + 1;
        }
    }
}
