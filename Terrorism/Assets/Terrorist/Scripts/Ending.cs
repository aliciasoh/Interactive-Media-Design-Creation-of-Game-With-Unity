using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

	public Text textBox;
	//Store all your text in this string array
	private string goatText;
	private bool crawling = false;
	private PointSystem3 ps;
	public int totalPoints;
	public string pointGrade;

	void Start(){

		GameObject pointsController = GameObject.FindGameObjectWithTag ("ps3");
		ps = pointsController.GetComponent <PointSystem3>();

		totalPoints = ps.totalPoints;
		pointGrade = ps.pointGrade;

		textBox.text = "Congratulations! \n\nYou have successfully completed your terrorism missions!\n\n\n\nYour Terrorist Score: " + totalPoints + "% " + pointGrade + "\n\n\n\nPress 'n' to play again";


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
