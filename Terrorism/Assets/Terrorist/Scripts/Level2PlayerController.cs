using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;



[RequireComponent(typeof(AudioSource))]
public class Level2PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	public float speed;				//Floating point variable to store the player's movement speed.
	public float runSpeed;				//Floating point variable to store the player's movement speed.

	public AudioClip walkSound;										// Reference to the audio source which will play our shooting sound effect
	public AudioClip keySound;
	public AudioClip runSound;										// Reference to the audio source which will play our shooting sound effect


	public Text gunText;
	public Text caughtText;


	private int gunsCollected = 0;  
	public int caught = 0;   
	private int shotguns = 0;  


	public GameObject playerObject;

	//Used to store player food points total during level.

	private Level2GameController level2GameController;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gunText.text = "Pistols Collected: " + gunsCollected + " | Shotgun Collected: " + shotguns;
		caughtText.text = "No. of Times Caught: " + caught;

		InvokeRepeating ("PlayWalk", 0.0f, 0.3f);
		InvokeRepeating ("PlayRun", 0.0f, 0.3f);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("Level2GameController");
		level2GameController = gameControllerObject.GetComponent <Level2GameController>();



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


	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Exit")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			gunsCollected = gunsCollected + 1;
			gunText.text = "Pistols Collected: " + gunsCollected + " | Shotgun Collected: " + shotguns;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();


		}

		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Soda")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			shotguns = shotguns + 1;
			gunText.text = "Pistols Collected: " + gunsCollected + " | Shotgun Collected: " + shotguns;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();

			speed = 3.0f;				//Floating point variable to store the player's movement speed.
			runSpeed= 5.0f;	

		}

		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Finish")) 
		{
			if (gunsCollected == 8 || shotguns==1) {

				SceneManager.LoadScene ("Mission3Story");

			} 
			else if (gunsCollected < 8) {
				gunText.text = "Collect either 1 shotgun or 8 pistols!";
				Invoke("ChangeText", 2f);

			} 
		}

	}

	//Hides black image used between levels
	void ChangeText()
	{
		//Disable the levelImage gameObject.
		gunText.text = "Pistols Collected: " + gunsCollected + " | Shotgun Collected: " + shotguns;

	}

	void OnCollisionEnter2D(Collision2D enemyHit)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (enemyHit.gameObject.CompareTag ("Enemy")) 
		{
			caught = caught + 1;
			gunsCollected = 0;
			shotguns = 0;  

			caughtText.text = "No. of Times Caught: " + caught;

			this.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
			GameObject enemy1 = GameObject.Find ("Enemy2 (3)");
			GameObject enemy2 = GameObject.Find ("Enemy2 (1)");

			enemy1.transform.position = new Vector3 (14.3f, 6.08f, 0.0f);
			enemy2.transform.position = new Vector3 (-4.58f, -6.66f, 0.0f);

			speed = 4.0f;
			runSpeed = 8.0f;
			level2GameController.GameOver();


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
