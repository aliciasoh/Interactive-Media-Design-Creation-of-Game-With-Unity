using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;

public class PointSystem2 : MonoBehaviour {
	public Text pointText;
	public int totalPoints;
	private string pointGrade;
	private PointSystem ps;


	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		GameObject pointsController = GameObject.FindGameObjectWithTag ("ps");
		ps = pointsController.GetComponent <PointSystem>();

		totalPoints = ps.totalPoints;
		pointText.text = "Terrorist Meter: " + totalPoints + "% " + pointGrade;

	}

	public void changePoints(){
		totalPoints = totalPoints - 5;
	}
		

	// Update is called once per frame
	void Update () {

		if (totalPoints >= 100) {
			pointGrade = "Super Duper Terrorist";
		} else if (totalPoints >= 80 && totalPoints < 100) {
			pointGrade = "Super Terrorist";
		} else if (totalPoints >= 60 && totalPoints < 80) {
			pointGrade = "Average Terrorist";
		} else if (totalPoints >= 40 && totalPoints < 60) {
			pointGrade = "CMI Terrorist";
		} else if (totalPoints >= 20 && totalPoints < 60) {
			pointGrade = "Like Mas Selamat";
		} else if (totalPoints >= 0 && totalPoints < 20) {
			pointGrade = "Baby Mas Selamat";
		}


		pointText.text = "Terrorist Meter: " + totalPoints + "% " + pointGrade;



	}
}
