using System;
using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool RocketIsAttached;

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
		x = Input.GetAxis("GarbageH1");
		y = Input.GetAxis("GarbageV1");
        Rotate();

        //Debug.LogWarning (Input.GetAxis ("GarbageF1"));

        if (Input.GetAxis ("GarbageF1") == -1) {
     		
			if (rocket.transform.parent != null) {
				rocket.transform.parent = null;

			 
				angle1 = transform.eulerAngles.z;

                if (angle1 > 270 && angle1 < 360 && transform.localScale == new Vector3(-1, 1, 1))
                {
                    angle1 = angle1 - 180;
                }
                else if (angle1 > 0 && angle1 < 90 && transform.localScale == new Vector3(-1, 1, 1))
                {
                    angle1 = angle1 + 180; 
                }
                angle1 = angle1 * Mathf.Deg2Rad;

                rocket.GetComponent<Rigidbody>().velocity = Vector2.zero;
                rocket.GetComponent<Rigidbody>().AddForce(new Vector2(Mathf.Cos(angle1) * force * 10, 
                                                                      Mathf.Sin(angle1) * force * 10));
                //rocket.GetComponent<Rigidbody>().AddForce( rocket.transform.forward * force * 20000 * Time.deltaTime);
                RocketIsAttached = false;
  

			    var smoke = Instantiate(RocketSmokeAnimation);
			    smoke.transform.parent = rocket.transform;
                smoke.transform.localPosition = new Vector3(-9,1,0);
			    smoke.transform.rotation = rocket.transform.rotation;

                Animator smokeAnimator = smoke.GetComponent<Animator>();
                if (smokeAnimator != null) smokeAnimator.enabled = true;

                GetComponent<Rigidbody> ().AddForce (new Vector2 (-Mathf.Cos(angle1), -Mathf.Sin(angle1)) * force / 2.5f);
			}
		}

        if (!RocketIsAttached)
        {
            //rocket.transform.Translate(new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1)) * force * 20 * Time.deltaTime);
             
        }
      

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

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cage")
		{
			SceneManager.LoadScene("CamGuyWin");

		}

        if (other.gameObject.tag == "Projectile")
        {
            hitByProjectile = true;
        }
	}
    
     
}
