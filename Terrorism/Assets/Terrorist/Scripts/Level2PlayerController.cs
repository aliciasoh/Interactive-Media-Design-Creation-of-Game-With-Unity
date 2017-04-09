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
	private PointSystem2 ps;

	//Used to store player food points total during level.

	private Level2GameController level2GameController;
	private CheckCaught2 checkCaught;
	private bool isColliding;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gunText.text = "TNT Collected: " + gunsCollected + " | Bombs Collected: " + shotguns;
		caughtText.text = "No. of Times Caught: " + caught;

		Debug.Log ("start");

		InvokeRepeating ("PlayWalk", 0.0f, 0.3f);
		InvokeRepeating ("PlayRun", 0.0f, 0.3f);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("Level2GameController");
		level2GameController = gameControllerObject.GetComponent <Level2GameController>();

		GameObject checkCaughtObject = GameObject.FindGameObjectWithTag ("CheckCaught2");
		checkCaught = checkCaughtObject.GetComponent <CheckCaught2>();

		GameObject pointsController = GameObject.FindGameObjectWithTag ("ps2");
		ps = pointsController.GetComponent <PointSystem2>();
	}

	// Update is called once per frame
	void Update () {

		checkCaught.SetCaught (caught);

		isColliding = false;
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


	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (isColliding)
			return;
		isColliding = true;
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("pistol")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);

			gunsCollected++;
			level2GameController.AddPistol ();


			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();


		}

		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		else if (other.gameObject.CompareTag ("Shotgun")) 
		{
			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive(false);
			//level2GameController.AddShotgun ();

			shotguns = 1;
			level2GameController.AddShotgun ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();

			speed = 3.0f;				//Floating point variable to store the player's movement speed.
			runSpeed= 5.0f;	

		}

		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		else if(other.gameObject.CompareTag ("Finish")) 
		{
			if (gunsCollected == 8 || shotguns==1) {

				SceneManager.LoadScene ("Mission3Story");

			} 
			else if (gunsCollected < 8 || shotguns!=1) {
				gunText.text = "Collect either 1 bomb or 8 TNTs!";
				Invoke("ChangeText", 2f);

			} 
		}

	}

	//Hides black image used between levels
	void ChangeText()
	{
		//Disable the levelImage gameObject.
		gunText.text = "TNT Collected: " + gunsCollected + " | Bombs Collected: " + shotguns;

	}

	void OnCollisionEnter2D(Collision2D enemyHit)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (enemyHit.gameObject.CompareTag ("Enemy")) 
		{
			caught = caught + 1;

			ps.changePoints ();

			caughtText.text = "No. of Times Caught: " + caught;

			this.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
			GameObject enemy1 = GameObject.Find ("Enemy2 (3)");
			GameObject enemy2 = GameObject.Find ("Enemy2 (1)");

			enemy1.transform.position = new Vector3 (14.3f, 6.08f, 0.0f);
			enemy2.transform.position = new Vector3 (-4.58f, -6.66f, 0.0f);

			speed = 4.0f;
			runSpeed = 8.0f;

			if (caught == 20) {
				SceneManager.LoadScene ("Restart");

			}

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
