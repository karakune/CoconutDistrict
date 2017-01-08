using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        // lock x y rotation du to collider collisions.
		gameObject.transform.rotation.Set(0,0, gameObject.transform.rotation.z,0);
	}
}
