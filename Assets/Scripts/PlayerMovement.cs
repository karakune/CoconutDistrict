using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class PlayerMovement : MonoBehaviour {

    private float x;
    private float y;
	private float x1;
	private float y1;
    private float shot;
    private float angle;
	private float angle1;
	private Vector2 dir;
	private Vector3 playerPosition;
	private Vector3 foo;

    public GameObject RocketSmokeAnimation;
    public GameObject rocket;
	public float force;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		x = Input.GetAxis("GarbageH1");
		y = Input.GetAxis("GarbageV1");
        if (x == 0 && y == 0)
        {
        }
        else
        {
            Rotate();
        }

		//Debug.LogWarning (Input.GetAxis ("GarbageF1"));

		if (Input.GetAxis ("GarbageF1") == -1) {
     		
			if (rocket.transform.parent != null) {
				rocket.transform.parent = null;
				Debug.LogWarning (Input.GetAxis ("GarbageF1"));
				angle1 = transform.eulerAngles.z;
				if (angle1 > 270 && angle1 < 360 && transform.localScale == new Vector3 (-1, 1, 1)) {
					angle1 = angle1 - 180;
				}
				else if(angle1 > 0 && angle1 < 90 && transform.localScale == new Vector3 (-1, 1, 1)){
					angle1 = angle1 + 180;
				}
				angle1 = angle1 * Mathf.Deg2Rad;
				rocket.GetComponent<Rigidbody> ().velocity = Vector2.zero;
				rocket.GetComponent<Rigidbody> ().AddForce (new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * force * 20 * Time.deltaTime);

			    var smoke = Instantiate(RocketSmokeAnimation);
			    smoke.transform.parent = rocket.transform;
                smoke.transform.localPosition = new Vector3(-9,1,0);
			    smoke.transform.rotation = rocket.transform.rotation;

                Animator smokeAnimator = smoke.GetComponent<Animator>();
                if (smokeAnimator != null) smokeAnimator.enabled = true;

                GetComponent<Rigidbody> ().AddForce (new Vector2 (-Mathf.Cos(angle1), -Mathf.Sin(angle1)) * force/2 * Time.deltaTime);
			}
		} 
			
		/*
		if(Mathf.Abs(Input.GetAxis("GarbageF1")) < ){
			
		}*/
		//Debug.LogWarning (Input.GetAxis ("GarbageF1"));
        //p1.transform.parent = Camera.main.transform;
    }
		void Rotate(){
        if (x > 0 && y != 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            angle = Mathf.Atan2(-y, x) * Mathf.Rad2Deg;
        }
        else if (x < 0 && y != 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            angle = Mathf.Atan2(y, -x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
			Debug.LogWarning ("oh no!!");
		}
	}
}
