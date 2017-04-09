using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;



[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.
	public float speed;				//Floating point variable to store the player's movement speed.
	public float runSpeed;				//Floating point variable to store the player's movement speed.

	public AudioClip walkSound;										// Reference to the audio source which will play our shooting sound effect
	public AudioClip keySound;
	public AudioClip runSound;										// Reference to the audio source which will play our shooting sound effect


	public Text keyText;
	public Text caughtText;


	private int keysCollected = 0;  
	public int caught = 0;   


	public GameObject playerObject;
	private PointSystem ps;
	//Used to store player food points total during level.

	private GameController gameController;
	private CheckCaught checkCaught;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		keyText.text = "Keys Collected: " + keysCollected;
		caughtText.text = "No. of Times Caught: " + caught;

		InvokeRepeating ("PlayWalk", 0.0f, 0.3f);
		InvokeRepeating ("PlayRun", 0.0f, 0.3f);


		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();
	
		GameObject checkCaughtObject = GameObject.FindGameObjectWithTag ("CheckCaught");
		checkCaught = checkCaughtObject.GetComponent <CheckCaught>();

		GameObject pointsController = GameObject.FindGameObjectWithTag ("ps");
		ps = pointsController.GetComponent <PointSystem>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {



		checkCaught.SetCaught (caught);


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

		if (caught == 20) {
			SceneManager.LoadScene ("Restart");

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
			keysCollected = 1;
			keyText.text = "Keys Collected: " + keysCollected;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip =  keySound; 
			audio.Play ();


		}

		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("Finish")) 
		{
			if (keysCollected == 1) {
				SceneManager.LoadScene ("Mission2Story");
			} 
			else if (keysCollected == 0) {
				keyText.text = "Collect the key first!";
				Invoke("ChangeText", 2f);

			} 
		}

	}

	//Hides black image used between levels
	void ChangeText()
	{
		//Disable the levelImage gameObject.
		keyText.text = "Keys Collected: " + keysCollected;

	}

	void OnCollisionEnter2D(Collision2D enemyHit)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (enemyHit.gameObject.CompareTag ("Enemy")) 
		{
			caught = caught + 1;

			ps.changePoints ();

			keysCollected = 0;
			caughtText.text = "No. of Times Caught: " + caught;

			this.transform.position = new Vector3 (0.0f, 0.0f, -1.0f);
			GameObject enemy1 = GameObject.Find ("Enemy2");
			GameObject enemy2 = GameObject.Find ("Enemy2 (1)");
			GameObject enemy3 = GameObject.Find ("Enemy2 (2)");
			GameObject enemy4 = GameObject.Find ("Enemy2 (3)");

			enemy1.transform.position = new Vector3 (10.28f, 0.21f, 0.0f);
			enemy2.transform.position = new Vector3 (-9.09f, 0.21f, 0.0f);
			enemy3.transform.position = new Vector3 (2.06f, 9.68f, 0.0f);
			enemy4.transform.position = new Vector3 (13.37f, -7.49f, 0.0f);


			gameController.GameOver();


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
