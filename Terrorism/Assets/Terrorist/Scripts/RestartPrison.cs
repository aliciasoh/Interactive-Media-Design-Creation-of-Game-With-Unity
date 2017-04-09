using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class RestartPrison : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	private string goatText;
	private bool crawling = false;

	void Start(){
		textBox.text = "You are such a lousy terrorist\n\nthat the authorities caught you again\n\nand sent you back to prison.\n\n\n\nYour Terrorist Score: 0% Baby Mas Selamat \n\n\n\nPress 'n' to start again";


	}
	//This is a function for a button you press to skip to the next text

	// Update is called once per frame
	void FixedUpdate () {
		if (!crawling) {
			transform.Translate (Vector3.up * Time.deltaTime * 50.0f);
		}


		if (gameObject.transform.position.y > 300.0f)
		{
			crawling = true;
		}

		if (Input.GetKeyDown (KeyCode.N))
		{

			SceneManager.LoadScene ("Starting");


		}

	}



}
