using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array


	void Start(){



	}
	//This is a function for a button you press to skip to the next text

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.N))
		{

			SceneManager.LoadScene ("Story");


		}

	}



}
