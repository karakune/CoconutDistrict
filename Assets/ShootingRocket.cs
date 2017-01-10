using UnityEngine;
using System.Collections;

public class ShootingRocket : MonoBehaviour {
	public GameObject Perso;

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
		

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
            Debug.LogWarning("Rocket collided with walls");
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
         
        gameObject.SetActive(false);
        transform.parent = Perso.transform.Find("Cube").transform;
        
        foo = new Vector3(1.56f, 0.36f, 0.15f);
        gameObject.transform.localPosition = foo;
      
        //GetComponent<BoxCollider>().velocity = Perso.transform.parent.GetComponent<Rigidbody>().velocity;
        transform.rotation = Perso.transform.parent.rotation;
        transform.rotation.Set(0,0, Perso.transform.parent.rotation.z,0);
        

        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gameObject.SetActive(true);

        Animator smoke = gameObject.GetComponentInChildren<Animator>();
        if (smoke != null) smoke.enabled = false;

      

        Perso.transform.parent.GetComponent<PlayerMovement>().RocketIsAttached = true;
    }
}
