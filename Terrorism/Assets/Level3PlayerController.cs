using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;



[RequireComponent(typeof(AudioSource))]
public class Level3PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	public float speed;				//Floating point variable to store the player's movement speed.
	public float runSpeed;				//Floating point variable to store the player's movement speed.

	public AudioClip walkSound;										// Reference to the audio source which will play our shooting sound effect
	public AudioClip keySound;
	public AudioClip runSound;										// Reference to the audio source which will play our shooting sound effect


	public Text caughtText;
	public Text timer;


	public int caught = 0;   
	public float time = 5.0f;

	public GameObject playerObject;

	//Used to store player food points total during level.

	private Level3GameController level3GameController;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		caughtText.text = "No. of Times Caught: " + caught;
		timer.text = "Bomb Timer: " + time + " Minutes Left";

		InvokeRepeating ("PlayWalk", 0.0f, 0.3f);
		InvokeRepeating ("PlayRun", 0.0f, 0.3f);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("Level3GameController");
		level3GameController = gameControllerObject.GetComponent <Level3GameController>();



	}

	// Update is called once per frame
	void FixedUpdate () {
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical);

		if (Input.GetKey (KeyCode.LeftShift)) {
			movement = movement.normalized * runSpeed * Time.deltaTime;
		} else {
			movement = movement.normalized * speed * Time.deltaTime;
		}



		rb2d.MovePosition (transform.position + movement);

		if (Input.GetKey (KeyCode.P)) {
			movement = movement.normalized * runSpeed * Time.deltaTime;
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
		if (other.gameObject.CompareTag ("Finish")) 
		{


				SceneManager.LoadScene ("Mission3Story");



		}

	}



	void OnCollisionEnter2D(Collision2D enemyHit)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (enemyHit.gameObject.CompareTag ("Enemy")) 
		{
			caught = caught + 1;
	

			caughtText.text = "No. of Times Caught: " + caught;

			this.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
			GameObject enemy1 = GameObject.Find ("Enemy2 (3)");
			GameObject enemy2 = GameObject.Find ("Enemy2 (1)");

			enemy1.transform.position = new Vector3 (14.3f, 6.08f, 0.0f);
			enemy2.transform.position = new Vector3 (-4.58f, -6.66f, 0.0f);


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
