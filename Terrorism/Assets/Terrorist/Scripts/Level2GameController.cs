using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;


public class Level2GameController: MonoBehaviour {

	public Text gunText;
	private int gunsCollected;  
	private int shotguns;  

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
			SceneManager.LoadScene ("Starting");


		}
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

	public void GameOver ()
	{

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip =  caughtSound; 
		audio.Play ();
		gunsCollected = 0;
		shotguns = 0;  

		gunText.text = "TNT Collected: " + gunsCollected + " | Bombs Collected: " + shotguns;
		//GameObject go = (GameObject)Instantiate (Resources.Load ("Guards"));
		//GameObject go1 = (GameObject)Instantiate (Resources.Load ("Enemy2 (1)"));

		GameObject guns = GameObject.FindGameObjectWithTag ("Respawn");
		Destroy (guns);

			GameObject go2 = (GameObject)Instantiate (Resources.Load ("Guns"));


	}

	public void AddPistol(){
		gunsCollected++;
		gunText.text = "TNT Collected: " + gunsCollected + " | Bombs Collected: " + shotguns;

	}

	public void AddShotgun(){
		shotguns++;
		gunText.text = "TNT Collected: " + gunsCollected + " | Bombs Collected: " + shotguns;

	}
}
