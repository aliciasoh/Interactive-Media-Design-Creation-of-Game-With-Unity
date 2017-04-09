using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	private string goatText;
	private bool crawling = false;

	void Start(){
		textBox.text = "You are a villager whose only source of water is River A.\n\nYou feel that the government has neglected you for profits \n\nand allowed big corporations such as ABCD and XXXX to pollute the water source. \n\nYou want to pressure the government \n\ninto disallowing big corporations from polluting your water source.\n\n\n\nPress 'n' to proceed";

	
	}
	//This is a function for a button you press to skip to the next text

	// Update is called once per frame
	void FixedUpdate () {
		if (!crawling) {
			transform.Translate (Vector3.up * Time.deltaTime * 50.0f);
		}


		if (gameObject.transform.position.y > 200.0f)
		{
			crawling = true;
		}

		if (Input.GetKeyDown (KeyCode.N))
		{
			
			SceneManager.LoadScene ("Story2");


		}

	}



}
