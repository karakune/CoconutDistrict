using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour {

	public GameObject[] images;


	void Start (){
		if (GameVars.currImage == null) {
			GameVars.currImage = 0;
		}
		GameVars.inIntro = true;

	}
	// Update is called once per frame
	void Update(){
	if (Input.anyKeyDown) {
			Play ();
		}

	}

	public void Play(){
		PlayerPrefs.DeleteAll ();
		if(!GameVars.inIntro){
			GameVars.inIntro = true;
			SceneManager.LoadScene ("Intro");
		}
		Time.timeScale = 1;
		if (images.Length != 0) {	
			ChangeImage ();
		}
	}

	public void GoBack(){
		SceneManager.LoadScene ("Menu");
	}

	public void CamGuyWin(){
		SceneManager.LoadScene ("CamGuyWin");
	}

	public void GarbageManWin(){
		SceneManager.LoadScene ("GarbageManWin");
	}

	public void ChangeImage(){
		Debug.Log (GameVars.currImage);
		Debug.Log (images.Length);
		if (GameVars.currImage < 3) {
			images [GameVars.currImage].SetActive(false);
			GameVars.currImage++;
		} else {
			//code for change scene
			SceneManager.LoadScene ("GameScene");
		}
	}

}