using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float boundary;
	public float playerVelocity;
	private Vector3 playerPosition;

	private int playerLives;
	private int playerPoints;

	public AudioClip pointSound;
	public AudioClip lifeSound;

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

		WinLose ();

	}

	void addPoints(int points){

		playerPoints += points;
		audio.PlayOneShot (pointSound);
	}

	void TakeLife(){

		playerLives--;
		audio.PlayOneShot (lifeSound);
	}

	void OnGUI(){

		GUI.Label (new Rect (5.0f, 3.0f, 200.0f, 200.0f), 
		           "Live's: " + playerLives + " Score: " + playerPoints);

	}

	void WinLose(){
		// restart the game
		if (playerLives == 0) {
			Application.LoadLevel("Level1");        
		}

		if ((GameObject.FindGameObjectsWithTag ("Block")).Length == 0) {
			// check the current level
			if (Application.loadedLevelName == "Level1") {
				Application.LoadLevel("Level2");
			} else {
				Application.Quit();
			}
		}

	}

}
