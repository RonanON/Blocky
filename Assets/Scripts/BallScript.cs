using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	private bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;

	public GameObject playerObject;

	// Use this for initialization
	void Start () {

		ballIsActive = false;

		ballInitialForce = new Vector2 (100.0f, 300.0f);

		ballPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Jump") == true){

			if (!ballIsActive){

				rigidbody2D.isKinematic = false;
				rigidbody2D.AddForce (ballInitialForce);
				ballIsActive = true;


			}
		
		}

		if (!ballIsActive && playerObject != null){

			ballPosition.x = playerObject.transform.position.x;

			transform.position = ballPosition;

		
		}

		if (ballIsActive && transform.position.y < -6) {
			ballIsActive = !ballIsActive;
			ballPosition.x = playerObject.transform.position.x;
			ballPosition.y = -4.2f;
			transform.position = ballPosition;

			rigidbody2D.isKinematic = true;
		}
	}
}
