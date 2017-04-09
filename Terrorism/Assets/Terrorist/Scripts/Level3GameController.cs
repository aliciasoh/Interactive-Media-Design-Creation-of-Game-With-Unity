using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;


public class Level3GameController: MonoBehaviour {


	public AudioClip caughtSound;	
	private CheckCaught2 checkCaught;

	// Use this for initialization
	void Start () {

		GameObject checkCaughtObject = GameObject.Find ("CheckCaught2");
		checkCaught = checkCaughtObject.GetComponent <CheckCaught2>();

		if (checkCaught.checkingCaught == 3 ||  checkCaught.checkingCaught == 4) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (3)");
			enemy3.SetActive (false);
		}
		else if (checkCaught.checkingCaught >=5) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (2)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (3)");
			enemy3.SetActive (false);
			enemy4.SetActive (false);
		}

	}

	// Update is called once per frame
	void FixedUpdate () {

		Debug.Log ("from level3gamecontroller " + checkCaught.checkingCaught);


		if (Input.GetKeyDown (KeyCode.Escape))
		{
			SceneManager.LoadScene ("Starting");


		}

		if (checkCaught.checkingCaught == 3 ||  checkCaught.checkingCaught == 4) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (3)");
			enemy3.SetActive (false);
		}
		else if (checkCaught.checkingCaught >=5) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (2)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (3)");
			enemy3.SetActive (false);
			enemy4.SetActive (false);
		}

	}

	public void GameOver ()
	{

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip =  caughtSound; 
		audio.Play ();
	





	}
}
