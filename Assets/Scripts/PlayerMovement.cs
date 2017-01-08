using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float x;
    private float y;
    private float shot;
    private float angle;
	private Vector3 playerPosition;
	private Vector3 foo;
//    private bool isShooted = false;


    public GameObject rocket;
	public float force;

    GameObject stun1;
    GameObject stun2;
    GameObject perso;
    bool hitByProjectile = false;
    public int stunTime;
    private int framesCounted = 0;

    // Use this for initialization
    void Start()
    {
        stun1 = GameObject.Find("Stun1");
        stun2 = GameObject.Find("Stun2");
        stun1.SetActive(false);
        stun2.SetActive(false);
        perso = GameObject.Find("Perso");
    }

    // Update is called once per frame
    void Update()
    {
		//isShooted = false;
		x = Input.GetAxis("GarbageH1");
		y = Input.GetAxis("GarbageV1");
        if (x == 0 && y == 0)
        {
        }
        else
        {
            Rotate();
        }
		if (Input.GetAxis ("GarbageF1") == -1) {
     		
			if (rocket.transform.parent != null) {
				//GameObject projectile = Instantiate (rocket, transform.position, Quaternion.identity) as GameObject;
				rocket.GetComponent<Rigidbody> ().AddForce (new Vector2 (x, -y) * force * 10 * Time.deltaTime);
				GetComponent<Rigidbody> ().AddForce (new Vector2 (-x, y) * force/2 * Time.deltaTime);
				rocket.transform.parent = null;

				/*playerPosition = this.transform.Find ("Cube").transform.position;
				foo = new Vector3 (1.56f, 0.28f, 0.0f);

				var myNewRocket = Instantiate (rocket, playerPosition + foo, Quaternion.identity) as GameObject;
				//myNewRocket.transform = this.transform.Find ("Cube").transform;
				rocket = myNewRocket;
				rocket.transform.parent = this.transform.Find ("Cube").transform;
				rocket.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
				rocket.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
				rocket.transform.rotation = this.transform.rotation;*/



					/*//Debug.Log ("Entered on trigger collide");
					this.gameObject.SetActive (false);
					this.transform.parent = player.transform.Find("Cube").transform;
					//Debug.Log ("supposed to re attach");
					foo = new Vector3 (1.56f, 0.28f, 0.0f);

					//this.gameObject.transform.position =  player.transform.Find("Cube").transform.position + foo;
					this.gameObject.transform.localPosition =  foo;
					//Debug.Log ("repositonned");
					this.GetComponent<Rigidbody> ().velocity = player.transform.parent.GetComponent<Rigidbody>().velocity;
					this.transform.rotation = player.transform.parent.rotation; 
					this.gameObject.SetActive (true);*/
			}

			//rocket.GetComponent<ShootingRocket> ().shoot (x, y);
		} 
		/*else {
			isShooted = false;
		}*/
        /*if (isShooted)
        {
            GameObject p1 = Instantiate(rocket);
            System.Threading.Thread.Sleep(10);
        }
        */
		/*
		if(Mathf.Abs(Input.GetAxis("GarbageF1")) < ){
			
		}*/
		//Debug.LogWarning (Input.GetAxis ("GarbageF1"));
        //p1.transform.parent = Camera.main.transform;

        if(hitByProjectile == true)
        {
            framesCounted++;
        }

        if(framesCounted > 0)
        {
            if(framesCounted % 2 != 0)
            {
                perso.SetActive(false);
                stun1.SetActive(true);
                stun2.SetActive(false);
            }else
            {
                perso.SetActive(false);
                stun1.SetActive(false);
                stun2.SetActive(true);
            }
            if(framesCounted > stunTime)
            {
                framesCounted = 0;
                hitByProjectile = false;
                perso.SetActive(true);
                stun1.SetActive(false);
                stun2.SetActive(false);
            }
        }
    }
		void Rotate(){
    
        //Debug.Log(x);
        //Debug.Log(y);
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

        if (other.gameObject.tag == "Projectile")
        {
            hitByProjectile = true;
        }
	}/*
	public void setIsShooted(bool isShooted){
		this.isShooted = isShooted;
	}*/
}
