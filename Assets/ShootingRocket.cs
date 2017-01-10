using UnityEngine;
using System.Collections;

public class ShootingRocket : MonoBehaviour {
	public GameObject Perso;

    public GameObject BoomAnimation;

    private Vector3 playerPosition;
	
	private Quaternion lol;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = new Vector3(1.56f, 0.28f, 0.15f);
    }
	
	// Update is called once per frame
	public void Update ()
	{
        if(Perso.transform.parent.GetComponent<PlayerMovement>().RocketIsAttached)
            gameObject.transform.localPosition = offset;
    }
		

	public void OnTriggerEnter(Collider other)
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
        
        
        Perso.transform.parent.GetComponent<PlayerMovement>().RocketIsAttached = true;
         
        gameObject.GetComponent<Rigidbody>().velocity = Perso.transform.parent.GetComponent<Rigidbody>().velocity;
      
        gameObject.SetActive(false);
        transform.parent = Perso.transform.Find("Cube").transform;
        

       
        gameObject.transform.localPosition = offset;
        gameObject.transform.localRotation = Quaternion.identity;
         //GetComponent<BoxCollider>().velocity = Perso.transform.parent.GetComponent<Rigidbody>().velocity;
        transform.rotation = Perso.transform.parent.rotation;
        transform.rotation.Set(0,0, Perso.transform.parent.rotation.z,0);
        

        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        gameObject.SetActive(true);

        Animator smoke = gameObject.GetComponentInChildren<Animator>();
        if (smoke != null) smoke.enabled = false;

        

    }
}
