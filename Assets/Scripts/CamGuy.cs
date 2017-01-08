using UnityEngine;
using System.Collections;
using System;

public class CamGuy : MonoBehaviour {

    public float speed;
    public GameObject projectile;
    bool shotFired = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
		Camera.main.transform.Translate(Input.GetAxis("CamGuy X") * speed * Time.deltaTime,
			Input.GetAxis("CamGuy Y") * speed * Time.deltaTime * 1, 0);
        //Debug.Log(Input.GetAxis("Fire1"));
        //right trigger pressed
		if (Input.GetAxis("CamGuy Projectile") == -1 && !shotFired)
        {
            GameObject p1 = Instantiate(projectile);
            p1.transform.parent = Camera.main.transform;
            shotFired = true;
        }
        //compensate for dead zone
        //if(Math.Abs(Input.GetAxis("Fire1")) < 0.015)
        //{
        //    shotFired = false;
        //}

    }

    public void SetShotFired(bool value)
    {
        shotFired = value;
    }
}
