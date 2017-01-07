using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
     
    public bool Shaking;
    public float IntialShakeIntensity = 0.4F;
    public float InitialShakeDecay = 0.02f;

    private float ShakeDecay;
    private float ShakeIntensity;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;


    // Use this for initialization
    public void Start () {
        Shaking = false;
    }
	
	// Update is called once per frame
	public void FixedUpdate () {

       
        if (ShakeIntensity > 0)
        {
            transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f);

            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
        }

    }


    public void OnGUI()
    {

        if (GUI.Button(new Rect(10, 200, 50, 30), "Shake"))
            DoShake();
        Debug.Log("Shake");

    }
     

    public void DoShake()
    {
        OriginalPos = transform.position;
        OriginalRot = transform.rotation;

        ShakeIntensity = IntialShakeIntensity;
        ShakeDecay = InitialShakeDecay;
        Shaking = true;
    }
}
