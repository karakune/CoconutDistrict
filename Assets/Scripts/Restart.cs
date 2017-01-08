using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    private float timePassed;
	// Use this for initialization
	void Start ()
	{
	    timePassed = 0;
	    GameVars.inRestart = true;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    timePassed += Time.deltaTime;
	    if ((Input.anyKeyDown && timePassed > 1) || timePassed > 3)
	        SceneManager.LoadScene("GameScene");
	}
}
