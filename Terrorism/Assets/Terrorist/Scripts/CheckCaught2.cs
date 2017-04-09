using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCaught2 : MonoBehaviour {

	public int checkingCaught;
	private int caught;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
	}

	public void SetCaught(int caught){
		checkingCaught = caught;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("from checkcaught2 " + checkingCaught);
	}
}
