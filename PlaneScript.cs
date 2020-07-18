using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current = 0;
    public static bool ReachedDestination = false;
    public GameManager Gm;
    // Use this for initialization
    void Start()
    {
        ReachedDestination = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ReachedDestination)
        {
            if (transform.position != target[current].position)
            {
              //  Debug.Log("f");
                Quaternion rot = Quaternion.RotateTowards(transform.rotation, target[current].rotation, 60 * Time.deltaTime);
                GetComponent<Rigidbody>().MoveRotation(rot);
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
               // Debug.Log("f");
                //GetComponent<Rigidbody>().isKinematic = true;

                if (target.Length > current + 1)
                {

                    current = current + 1;

                }
            }
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.gameObject.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="trigger")
        {
            GameObject.Find("Player Character Model(Clone)").SetActive(false);
            Gm.Levels[0].transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            Gm.Levels[0].transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(false);
            Gm.Levels[0].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
            Debug.Log("gfg");
            ReachedDestination = true;
            this.transform.gameObject.SetActive(false);
        }
    }
}
