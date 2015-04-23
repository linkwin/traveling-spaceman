using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipState : MonoBehaviour {
	
	public Queue<Vector2> movementQueue;
	public Queue<Vector2> destinationQueue;
	public Vector2 movement = Vector2.zero;
	public Vector2 destination;
	private float speed = 0.75f;
	public int currentPlanet = 0;
	public bool endgame = false;
	public Vector2 end;
	private PlayerStats stats;



	void Start() {
		movementQueue = new Queue<Vector2> ();
		destinationQueue = new Queue<Vector2> ();
		destination = this.transform.position;
		stats = GetComponent<PlayerStats> ();
	}

	void Update () {
		if (movement == Vector2.zero && movementQueue.Count != 0) {
				movement = (Vector3)movementQueue.Dequeue ();
				destination = (Vector3)destinationQueue.Dequeue();
		}

		if (movement != Vector2.zero) {
						transform.Translate (movement * Time.deltaTime);
						transform.position = Vector3.RotateTowards (transform.position, destination, speed * Time.deltaTime, Time.deltaTime);
						movement -= movement * Time.deltaTime;
				}
		if (movement.magnitude < 0.1)
						movement = Vector2.zero;
		Point shipPos = new Point ((int)this.transform.position.x, (int)this.transform.position.y);
		Point earthPos = new Point ((int)end.x, (int)end.y);
		if (endgame && shipPos.Distance (earthPos) < 3) {
						MainController.displayScore = stats.score;
						endGame ();
				}

/*		if (movement != Vector2.zero) {
			transform.Translate (movement * Time.deltaTime);
			movement -= movement * Time.deltaTime;
			if (movement.magnitude < 0.01 && o < i) {
				movement = (Vector2) (positionQueue[o+1] - 
				                                positionQueue[o]);
				o++;
			}
		}*/
	}
	void OnCollisionEnter(Collision collision) {
		Debug.Log ("collide");
		if (currentPlanet == 0) {
			endGame();
		}
	}
	void endGame() {
		Application.LoadLevel ("endScreen");
	}
	
}
