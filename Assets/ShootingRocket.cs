using UnityEngine;
using System.Collections;

public class ShootingRocket : MonoBehaviour {
	//public float force;
	public GameObject player;
	private Vector3 playerPosition;
	private Vector3 foo;
	private Quaternion lol; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*public void shoot(float x, float y){
		GameObject rocket = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		rocket.GetComponent<Rigidbody> ().AddForce(new Vector3(x,y,0)* force);
	}*/

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
			Debug.Log ("Entered on trigger collide");
			gameObject.SetActive (false);
			transform.parent = player.transform.Find("Cube").transform;
			Debug.Log ("supposed to re attach");
			foo = new Vector3 (1.56f, 0.36f, 0.15f);
			
			//this.gameObject.transform.position =  player.transform.Find("Cube").transform.position + foo;
			gameObject.transform.localPosition =  foo;
			Debug.Log ("repositonned");
			GetComponent<Rigidbody> ().velocity = player.transform.parent.GetComponent<Rigidbody>().velocity;
			transform.rotation = player.transform.parent.rotation;
			transform.localScale = new Vector3( 0.2f,0.2f,0.2f);


			//transform.localScale = new Vector3(player.transform.parent.localScale.x * 0.25f,0.25f,0.25f); 

			//gameObject.GetComponent<Rigidbody>().angularVelocity = Vector2.zero;
			gameObject.SetActive (true);
			Debug.Log(transform.localScale.x + " c");
		}
	}
}
