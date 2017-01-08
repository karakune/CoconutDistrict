using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float x;
	private float y;
	private float shot;
	private float angle;
	private bool isShooted = false;

	public GameObject rocket;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Vertical");
		if (x == 0 && y == 0) {
		} 
		else {
			Rotate ();
		}
		if (Input.GetAxis ("Fire1") == -1) {
			isShooted = true;
		} 
		else {
			isShooted = false;
		}
		if (isShooted) {
			GameObject p1 = Instantiate(rocket);
			System.Threading.Thread.Sleep (10);
		}

		//p1.transform.parent = Camera.main.transform;
	}

	void Rotate(){
		Debug.Log (x);
		Debug.Log (y);
		if (x > 0 && y != 0) {
			transform.localScale = new Vector3 (1, 1, 1);
			angle = Mathf.Atan2 (y, x) * Mathf.Rad2Deg;
		} 
		else if (x < 0 && y != 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
			angle = Mathf.Atan2 (-y, -x) * Mathf.Rad2Deg;
		}
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
			Debug.Log("die");
		}
	}
}
