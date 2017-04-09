using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {


	public AudioClip level1;										// Reference to the audio source which will play our shooting sound effect
	public AudioClip level2;
	public AudioClip level3;										// Reference to the audio source which will play our shooting sound effect
	private bool playing1 = false;
	private bool playing2 = false;
	private bool playing3 = false;


	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip =  level1; 
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Pollute") && playing1 == false){

			playing1 = true;
			playing2 = false;
			playing3 = false;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  level3; 
			audio.Stop ();


			AudioSource audio1 = GetComponent<AudioSource> ();
			audio1.clip =  level2; 
			audio1.Stop ();	

			AudioSource audio2 = GetComponent<AudioSource> ();
			audio2.clip =  level1; 
			audio2.Play ();		

		}

		if(GameObject.Find("jumping") && playing2 ==false){
			playing1 = false;
			playing2 = true;
			playing3 = false;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  level1; 
			audio.Stop ();


			AudioSource audio1 = GetComponent<AudioSource> ();
			audio1.clip =  level2; 
			audio1.Play ();		
		
		}

		if(GameObject.Find("wea") && playing3==false){
			playing1 = false;
			playing2 = false;
			playing3 = true;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  level1; 
			audio.Stop ();


			AudioSource audio1 = GetComponent<AudioSource> ();
			audio1.clip =  level2; 
			audio1.Stop ();	

			AudioSource audio2 = GetComponent<AudioSource> ();
			audio2.clip =  level3; 
			audio2.Play ();		

		}
	}
}
