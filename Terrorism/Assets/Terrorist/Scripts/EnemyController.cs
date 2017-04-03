using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	//The target player
	public Transform player;
	//At what distance will the enemy walk towards the player?
	public float walkingDistance;

	public float speed;				//Floating point variable to store the player's movement speed.
	private Vector3 OriPosition;

	void Start(){
		OriPosition = transform.position;

	}

	//Call every frame
	void Update()
	{
		//Calculate distance between player
		float distance = Vector3.Distance(transform.position, player.position);
		//If the distance is smaller than the walkingDistance

		if (distance > walkingDistance) {
			transform.position = Vector3.MoveTowards(transform.position, OriPosition, speed* Time.deltaTime);


		}
		else if(distance <= walkingDistance)
		{
			//Move the enemy towards the player with smoothdamp
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed* Time.deltaTime);
		}
	}
}