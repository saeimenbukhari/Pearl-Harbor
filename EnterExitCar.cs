using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnterExitCar : MonoBehaviour {
    public Text whatToDo;
    GameObject fpsPlayer;
    public AI Enemies;
    GameManager GM;
    public bool ExitCar = false;
    public bool PlayingArcadeMode = false;
    public GameObject VehicleGetInButton, VehicleGetOutButton;
	// Use this for initialization
	void Start () {
        GameManager.IsDriving = false;
        GM = FindObjectOfType<GameManager>();
        fpsPlayer = FindObjectOfType<FPSPlayer>().gameObject;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (fpsPlayer != null)
        {
            if (Vector3.Distance(transform.position, fpsPlayer.transform.position) < 3 && !GameManager.IsDriving)
            {
                GM.TutorialInstructions.text = "";
                GM.Levels[PlayerPrefs.GetInt("LevelNo", 1) - 1].transform.GetChild(1).gameObject.SetActive(true);
                whatToDo.text = "Press Enter Car Button to Get in Vehicle";
                VehicleGetInButton.SetActive(true);
                if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.X))
                {
                    VehicleGetInButton.SetActive(false);
                    VehicleGetOutButton.SetActive(true);
                    GM.TutorialInstructions.text = "Go and Hunt Enemies by following map";
                    this.GetComponent<bl_MiniMapItem>().enabled = false;
                    this.GetComponent<RCC_CarControllerV3>().canControl = true;
                    FindObjectOfType<bl_MiniMap>().m_Target = this.gameObject;
                    Debug.Log("f");
                    GameManager.IsDriving = true;
                    GM.EnterInCar();
                    FindObjectOfType<RCC_Camera>().playerCar = this.GetComponent<RCC_CarControllerV3>();
                }
            }
            else
                if (GameManager.IsDriving)
                {
                    if (this.GetComponent<RCC_CarControllerV3>().canControl && Vector3.Distance(transform.position, Enemies.transform.position) < 70 && (PlayerPrefs.GetInt("LevelNo", 1) == 4 || PlayerPrefs.GetInt("LevelNo", 1) == 5) && !PlayingArcadeMode)
                    {

                        this.GetComponent<RCC_CarControllerV3>().canControl = false;
                        this.GetComponent<Rigidbody>().isKinematic = true;
                        GM.SelectMode.SetActive(true);
                        fpsPlayer.transform.position = new Vector3(transform.position.x - 2, transform.position.y + 1, transform.position.z + 1);
                    }
                    else
                        if (PlayingArcadeMode)
                        {
                            this.GetComponent<RCC_CarControllerV3>().canControl = true;
                            this.GetComponent<Rigidbody>().isKinematic = false;
                            fpsPlayer.transform.position = new Vector3(transform.position.x - 5, transform.position.y + 1, transform.position.z + 1);
                        }
                    GM.TutorialInstructions.text = "";
                    whatToDo.text = "Press Walk Button to Exit Vehicle";
                    if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.X) || ExitCar)
                    {
                        VehicleGetInButton.SetActive(true);
                        VehicleGetOutButton.SetActive(false);
                        FindObjectOfType<bl_MiniMap>().m_Target = FindObjectOfType<FPSPlayer>().gameObject;
                        this.GetComponent<bl_MiniMapItem>().enabled = true;
                        this.GetComponent<RCC_CarControllerV3>().canControl = false;
                        GameManager.IsDriving = false;
                        ExitCar = false;
                        GM.ExitCar();
                    }
                }
                else
                {
                    if (VehicleGetInButton.activeInHierarchy)
                    {
                        VehicleGetInButton.SetActive(false);
                        VehicleGetOutButton.SetActive(false);
                    }
                    whatToDo.text = "";
                }
        }
    }
}
