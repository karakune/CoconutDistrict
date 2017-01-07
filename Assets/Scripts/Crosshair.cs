using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("hor: " + Input.GetAxis("CamGuy Crosshair X") + "ver: " + Input.GetAxis("CamGuy Crosshair Y"));
	    gameObject.transform.Translate(Input.GetAxis("CamGuy Crosshair X") * speed * Time.deltaTime,
            Input.GetAxis("CamGuy Crosshair Y") * speed * Time.deltaTime * -1, 0);
    }
}
