using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float boundary;
	public float playerVelocity;
	private Vector3 playerPosition;

	private int playerLives;
	private int playerPoints;

	// Use this for initialization
	void Start () {

		playerPosition = gameObject.transform.position;

		playerLives = 3;
		playerPoints = 0;
	
	}
	
	// Update is called once per frame
	void Update () {


		playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;

		if (Input.GetKeyDown (KeyCode.Escape)) {

			Application.Quit ();

		}

		transform.position = playerPosition;

		if (playerPosition.x < -boundary) {
			playerPosition.x = -boundary;
		} 
		if (playerPosition.x > boundary) {
			playerPosition.x = boundary;
		}

		transform.position = playerPosition;

	}

	void addPoints(int points){

		playerPoints += points;
	}

}
