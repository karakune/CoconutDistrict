using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed;
    private float edgeDistanceX;
    private float edgeDistanceY;
    GameObject horEdge;
    GameObject vertEdge;

	// Use this for initialization
	void Start () {
        vertEdge = GameObject.Find("Top Edge");
        horEdge = GameObject.Find("Right Edge");
        edgeDistanceX = (gameObject.transform.localScale.x / 2) - 
            (horEdge.transform.localPosition.x + horEdge.transform.localScale.x / 2);
        edgeDistanceY = (gameObject.transform.localScale.y / 2) -
            (horEdge.transform.localPosition.y + horEdge.transform.localScale.y / 2);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //stops the background from leaving the cam
        if(transform.localPosition.x > edgeDistanceX)
        {
            transform.localPosition = new Vector3(edgeDistanceX,
                transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < -edgeDistanceX)
        {
            transform.localPosition = new Vector3(-edgeDistanceX,
                transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y > edgeDistanceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, edgeDistanceY,
                transform.localPosition.z);
        }
        if (transform.localPosition.y < -edgeDistanceY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -edgeDistanceY,
                transform.localPosition.z);
        }


        gameObject.transform.Translate(Input.GetAxis("CamGuy X") * speed * Time.deltaTime * -1,
            Input.GetAxis("CamGuy Y") * speed * Time.deltaTime, 0);
    }
}
