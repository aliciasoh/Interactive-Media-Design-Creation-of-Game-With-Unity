using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class SeStoryController : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	private string goatText;
	private bool crawling = false;

	void Start(){
		textBox.text = "You staged peaceful protests with the rest of the villagers, \n\nbut you were caught and sent to prison for disruption of peace in the country. \n\nMany of your family members are contracting an illness \n\nand the government is turning a blind eye. \n\nYou want to break out from prison because you want to seek revenge.\n\n\n\nPress 'n' to start your mission";


	}
	//This is a function for a button you press to skip to the next text

	// Update is called once per frame
	void FixedUpdate () {
		if (!crawling) {
			transform.Translate (Vector3.up * Time.deltaTime * 50.0f);
		}


		if (gameObject.transform.position.y > 250.0f)
		{
			crawling = true;
		}


		if (Input.GetKeyDown (KeyCode.N))
		{
			SceneManager.LoadScene ("Terrorist");



		}
	}



}
