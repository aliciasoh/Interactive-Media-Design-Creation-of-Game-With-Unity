using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;


public class Level3GameController: MonoBehaviour {


	public AudioClip caughtSound;	
	private CheckCaught checkCaught;

	// Use this for initialization
	void Start () {

		GameObject checkCaughtObject = GameObject.Find ("CheckCaught");
		checkCaught = checkCaughtObject.GetComponent <CheckCaught>();

		if (checkCaught.checkingCaught == 3 ||  checkCaught.checkingCaught == 4) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (4)");
			enemy3.SetActive (false);
		}
		else if (checkCaught.checkingCaught >=5) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (4)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (5)");
			enemy3.SetActive (false);
			enemy4.SetActive (false);
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.Quit ();


		}

		if (checkCaught.checkingCaught == 3 ||  checkCaught.checkingCaught == 4) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (4)");
			enemy3.SetActive (false);
		}
		else if (checkCaught.checkingCaught >=5) {
			GameObject enemy3 = GameObject.Find ("Enemy2 (4)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (5)");
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
