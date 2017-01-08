using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public float speed;
    GameObject vertEdge;
    GameObject horEdge;
    bool shotFired;
    CamGuy camGuy;
    public Sprite redCrosshair;
    public Sprite greenCrosshair;

    // Use this for initialization
    void Start () {
        vertEdge = GameObject.Find("Top Edge");
        horEdge = GameObject.Find("Right Edge");
        camGuy = transform.parent.GetComponent<CamGuy>();
    }
	
	// Update is called once per frame
	void Update () {
        //stops the crosshair from going over the edge
        if(transform.localPosition.y > vertEdge.transform.localPosition.y - (vertEdge.transform.localScale.y / 2))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                vertEdge.transform.localPosition.y - (vertEdge.transform.localScale.y / 2), 
                transform.localPosition.z);
        }
        if (transform.localPosition.y < -vertEdge.transform.localPosition.y + (vertEdge.transform.localScale.y / 2))
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                -vertEdge.transform.localPosition.y + (vertEdge.transform.localScale.y / 2),
                transform.localPosition.z);
        }
        if (transform.localPosition.x > (horEdge.transform.localPosition.x - (horEdge.transform.localScale.x / 2)))
        {
            transform.localPosition = new Vector3(horEdge.transform.localPosition.x - (horEdge.transform.localScale.x / 2),
                transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < -horEdge.transform.localPosition.x + (horEdge.transform.localScale.x / 2))
        {
            transform.localPosition = new Vector3(-horEdge.transform.localPosition.x + (horEdge.transform.localScale.x / 2),
                transform.localPosition.y, transform.localPosition.z);
        }

        gameObject.transform.Translate(Input.GetAxis("CamGuy Crosshair X") * speed * Time.deltaTime,
            Input.GetAxis("CamGuy Crosshair Y") * speed * Time.deltaTime * -1, 0);

        if (camGuy.isShotFired())
        {
            GetComponent<SpriteRenderer>().sprite = redCrosshair;
        }else
        {
            GetComponent<SpriteRenderer>().sprite = greenCrosshair;
        }
    }
}
