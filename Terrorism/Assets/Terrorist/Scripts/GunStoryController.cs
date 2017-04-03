using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class GunStoryController : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	string goatText = "You have escaped out from prison. \n\nYou need to try to gather as much weapons \n\nbefore you start to plan your attack\n\n\n\nPress 'n' to start your mission";
	private bool crawling = false;

	void Start(){
		textBox.text = goatText;

	}


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
