using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;
using System;



[RequireComponent(typeof(AudioSource))]
public class Level3PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	public float speed;				//Floating point variable to store the player's movement speed.
	public float runSpeed;				//Floating point variable to store the player's movement speed.

	public AudioClip walkSound;										// Reference to the audio source which will play our shooting sound effect
	public AudioClip keySound;
	public AudioClip runSound;										// Reference to the audio source which will play our shooting sound effect
									// Reference to the audio source which will play our shooting sound effect


	public Text caughtText;
	public Text timer;


	public int caught = 0;   
	public float time;
	private float convert;

	public GameObject playerObject;
	private bool planted = false;
	private string timerConvert;

	//Used to store player food points total during level.

	private Level3GameController level3GameController;
	private explosion explode;
	private PointSystem3 ps;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		caughtText.text = "No. of Times Caught: " + caught;
		convert = time / 60;
		TimeSpan t = TimeSpan.FromMinutes (convert);
		timerConvert = String.Format ("{0}:{1:D2}", t.Minutes, t.Seconds);
		timer.text = "Bomb Timer: " + timerConvert + " Minutes Left";

		InvokeRepeating ("PlayWalk", 0.0f, 0.3f);
		InvokeRepeating ("PlayRun", 0.0f, 0.3f);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("Level3GameController");
		level3GameController = gameControllerObject.GetComponent <Level3GameController>();

		GameObject explodeController = GameObject.FindGameObjectWithTag ("explosion");
		explode = explodeController.GetComponent <explosion>();

		GameObject pointsController = GameObject.FindGameObjectWithTag ("ps3");
		ps = pointsController.GetComponent <PointSystem3>();

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (planted == true) {
			time -= Time.deltaTime;
			convert = time / 60;
			TimeSpan t = TimeSpan.FromMinutes (convert);
			string timerConvert = String.Format ("{0}:{1:D2}", t.Minutes, t.Seconds);
			timer.text = "Bomb Timer: " + timerConvert + " Minutes Left";

			if (time <= 0) {
				explode.explodeNow ();
			}
		}
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical);

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			movement = movement.normalized * runSpeed * Time.deltaTime;
		} else {
			movement = movement.normalized * speed * Time.deltaTime;
		}



		rb2d.MovePosition (transform.position + movement);

		GameObject player = GameObject.Find ("Player");
		GameObject bomb = GameObject.Find ("bomb");


		if (Input.GetKeyDown (KeyCode.P) && planted==false)
		{
			

			planted = true;
			bomb.transform.position = player.transform.position;
			explode.checkDistance (bomb.transform.position);

		}


	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Exit")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();


		}


		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Finish")  && planted==true) 
		{

			explode.explodeNow ();


		}
		if (other.gameObject.CompareTag ("Finish")  && planted==false) 
		{


			timer.text = "Plant the bomb first!";
			Invoke("ChangeText", 2f);


		}

	}

	void ChangeText()
	{
		//Disable the levelImage gameObject.
		timer.text = "Bomb Timer: " + timerConvert + " Minutes Left";

	}



	void OnCollisionEnter2D(Collision2D enemyHit)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (enemyHit.gameObject.CompareTag ("Enemy")) 
		{
			planted = false;
			GameObject bomb = GameObject.Find ("bomb");
			bomb.transform.position = new Vector3(-50.0f, 0.0f, -1.0f);

			caught = caught + 1;
			ps.changePoints ();


			caughtText.text = "No. of Times Caught: " + caught;

			this.transform.position = new Vector3 (-14.06f, -7.87f, -1.0f);
			GameObject enemy1 = GameObject.Find ("Enemy2");
			GameObject enemy2 = GameObject.Find ("Enemy2 (1)");
			GameObject enemy3 = GameObject.Find ("Enemy2 (2)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (3)");

			enemy1.transform.position = new Vector3 (-7.63f, 6.1f, -1.0f);
			enemy2.transform.position = new Vector3 (8.27f, -7.48f, -1.0f);
			enemy3.transform.position = new Vector3 (14.6f, 3.4f, -1.0f);
			enemy4.transform.position = new Vector3 (-7.25f, 0.7f, -1.0f);

			if (caught == 20) {
				SceneManager.LoadScene ("Restart");

			}

			level3GameController.GameOver();


		}
	}



	void PlayWalk(){
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  walkSound; 

			audio.Play ();
		} 
	}

	void PlayRun(){
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  runSound; 

			audio.Play ();
		} 
	}
}
