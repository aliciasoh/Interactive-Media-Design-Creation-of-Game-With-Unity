using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class explosion : MonoBehaviour {

	public AudioClip scream;	

	private bool gotHit;
	// Reference to the audio source which will play our shooting sound effect

	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		gotHit = false;
	}
	
	// Update is called once per frame
	void Update () {



			
	}

	public void explodeNow(){



		AudioSource audio1 = GetComponent<AudioSource> ();
		audio1.clip =  scream; 
		audio1.Play ();

		if (gotHit == false) {
			SceneManager.LoadScene ("Failed");
		} else if (gotHit == true) {
			SceneManager.LoadScene ("Ending");

		}

	}

	public void checkDistance(Vector3 bombPosition){
		Vector3 presidentPosition = new Vector3 (11.22f, 6.03f, -1.0f);
		float seeDistance = Vector3.Distance(bombPosition,presidentPosition);

		if (seeDistance > 5) {
			gotHit = false;
		}
		else if(seeDistance <= 5)
		{
			gotHit = true;
		}
	}
}
