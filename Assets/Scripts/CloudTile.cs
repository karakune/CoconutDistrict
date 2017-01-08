using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTile : MonoBehaviour {
    public float speed;
    public float tileSizeX;
    public float tileSizeY;

    private Vector3 startPosition;
    private float newPositionX;
    private float newPositionY;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        newPositionX = 0;
        newPositionY = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("CamGuy X") * speed * Time.deltaTime, 0, 0);
        newPositionX = Mathf.Repeat(newPositionX + Input.GetAxis("CamGuy X") * speed * Time.deltaTime, tileSizeX);
        newPositionY = Mathf.Repeat(newPositionY + Input.GetAxis("CamGuy Y") * speed * Time.deltaTime, tileSizeY);
        transform.localPosition = startPosition + (new Vector3(newPositionX, newPositionY, 0f));
    }
}
