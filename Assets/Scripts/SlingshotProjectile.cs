using UnityEngine;
using System.Collections;

public class SlingshotProjectile : MonoBehaviour {

    public float ySpeed;
    float proximity;
    //number of frames before object is destroyed
    public int lifespan;
    int framesCounted = 0;

    Camera parent;

    Vector3 startSpeed;

	// Use this for initialization
	void Start () {
        startSpeed = new Vector3(0, ySpeed, 1);
        GetComponent<Rigidbody>().AddForce(startSpeed * Time.deltaTime);

        parent = transform.parent.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        proximity = System.Math.Abs(0.1f / gameObject.transform.position.z);
        //ScaleByProximity();

        if(framesCounted < lifespan)
        {
            framesCounted++;
        }else
        {
            parent.GetComponent<CamGuy>().SetShotFired(false);
            Destroy(this.gameObject);
        }
    }

    void ScaleByProximity()
    {
        transform.localScale = new Vector3(proximity, proximity, 1);
    }
}
