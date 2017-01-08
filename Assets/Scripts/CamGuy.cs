using UnityEngine;
using System.Collections;
using System;

public class CamGuy : MonoBehaviour {

    public float speed;
    public GameObject projectile;
    bool shotFired = false;
    GameObject arc;
    GameObject crosshair;
    public float projectileDistance;

    // Use this for initialization
    void Start ()
    {
        arc = GameObject.Find("Arc");
        crosshair = GameObject.Find("Crosshair");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Camera.main.transform.Translate(Input.GetAxis("CamGuy X") * speed * Time.deltaTime,
            Input.GetAxis("CamGuy Y") * speed * Time.deltaTime * -1, 0);
        //Debug.Log(Input.GetAxis("Fire1"));
        //right trigger pressed
		if (Input.GetAxis("CamGuy Projectile") == -1 && !shotFired)
        {
            iTweenPath pathe = arc.GetComponent<iTweenPath>();
            pathe.nodes.Clear();
            pathe.nodes.Add(new Vector3(crosshair.transform.position.x,
                  crosshair.transform.position.y, 0f));
            pathe.nodes.Add(new Vector3(crosshair.transform.position.x,
                  -10f, projectileDistance));

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

    public bool isShotFired()
    {
        return shotFired;
    }

    public void SetShotFired(bool value)
    {
        shotFired = value;
    }
}
