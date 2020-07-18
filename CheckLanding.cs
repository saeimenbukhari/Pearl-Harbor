using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour {
    public FPSPlayer fps;
	// Use this for initialization
	void Start () {
        fps = FindObjectOfType<FPSPlayer>();	
	}
	void OnTriggerEnter(Collider other)
    {
        if(other.tag=="terrain")
        {
            PlayerPrefs.SetInt("Part2", 1);
            fps.levelLoadFadeObj.GetComponent<LevelLoadFade>().FadeAndLoadLevel(Color.black, 1.2f, false);
            //Application.LoadLevel(Application.loadedLevel);
           // this.gameObject.SetActive(false);
           // FindObjectOfType<GameManager>().Levels[0].transform.GetChild(1).gameObject.SetActive(false);
           // FindObjectOfType<GameManager>().Levels[0].transform.GetChild(4).gameObject.SetActive(true);
        }
    }
}
