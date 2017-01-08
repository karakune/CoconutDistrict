using UnityEngine;
using System.Collections;

public class ShootingRocket : MonoBehaviour {
	public GameObject player;

    public GameObject BoomAnimation;

    private Vector3 playerPosition;
	private Vector3 foo;
	private Quaternion lol; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
		

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
			ResetRocketInGun( other);
		}
        if (other.gameObject.tag == "Debris")
	    {
            
            var boom = Instantiate(BoomAnimation);
            boom.transform.position = this.transform.position;
            boom.transform.rotation = this.transform.rotation;

            Animator smokeAnimator = boom.GetComponent<Animator>();
            if (smokeAnimator != null) smokeAnimator.enabled = true;

            ResetRocketInGun( other);
	        ((SpriteRenderer) other.GetComponent<SpriteRenderer>()).enabled = false;

            ((ScoreManager)GameObject.FindObjectOfType(typeof(ScoreManager))).AddScore(50);
            Destroy(other);
        }
	}

    void ResetRocketInGun(Collider other)
    {
        Debug.Log("Entered on trigger collide");
        gameObject.SetActive(false);
        transform.parent = player.transform.Find("Cube").transform;
        Debug.Log("supposed to re attach");
        foo = new Vector3(1.56f, 0.36f, 0.15f);
        gameObject.transform.localPosition = foo;
        Debug.Log("repositonned");
        GetComponent<Rigidbody>().velocity = player.transform.parent.GetComponent<Rigidbody>().velocity;
        transform.rotation = player.transform.parent.rotation;
        transform.rotation.Set(0,0, player.transform.parent.rotation.z,0);
        

        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gameObject.SetActive(true);

        Animator smoke = gameObject.GetComponentInChildren<Animator>();
        if (smoke != null) smoke.enabled = false;

        Debug.Log(transform.localScale.x + " c");
    }
}
