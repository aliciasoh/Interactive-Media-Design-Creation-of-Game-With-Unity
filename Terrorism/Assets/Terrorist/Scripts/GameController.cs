using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public Text keyText;
	private int keysCollected;  

	private bool restart;
	public AudioClip caughtSound;	


	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.Escape))
			{
			Application.Quit ();


			}

	}

	public void GameOver ()
	{

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip =  caughtSound; 
		audio.Play ();
		keysCollected = 0;
		keyText.text = "Keys Collected: " + keysCollected;
		//GameObject go = (GameObject)Instantiate (Resources.Load ("Guards"));
		//GameObject go1 = (GameObject)Instantiate (Resources.Load ("Enemy2 (1)"));

		if (GameObject.Find ("key") == null) {
			//GameObject.Find ("key").gameObject.SetActive (true);
			GameObject go2 = (GameObject)Instantiate (Resources.Load ("key"));

		}


	}
}
