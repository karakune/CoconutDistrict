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
        parent = transform.parent.GetComponent<Camera>();
        gameObject.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, -10);
    }
	
	// Update is called once per frame
	void Update () {
        proximity = System.Math.Abs(0.1f * (gameObject.transform.localPosition.z + 0.5f));
        ScaleByProximity();

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
        transform.localScale = new Vector3(1 / proximity, 1 / proximity, 1);
    }
}
