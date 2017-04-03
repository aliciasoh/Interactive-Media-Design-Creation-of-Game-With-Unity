using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	private string goatText;
	private bool crawling = false;

	void Start(){
		textBox.text = "You have escaped out from prison. \n\nYou have to try to gather weapons \n\nbefore you start to plan your attack\n\n\n\nPress 'n' to start your mission";


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

			SceneManager.LoadScene ("Level2");


		}

	}



}
