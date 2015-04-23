using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

	private GameObject ship;
	private ShipState shipState;
	private bool visited;
	public int id;
	public static int displayScore;	
	private PlayerStats stats;
	void Start () {
		visited = false;
		ship = GameObject.Find ("spaceship");
		shipState = ship.GetComponent<ShipState> ();
		stats = ship.GetComponent<PlayerStats> ();
	}
	  
	/*void Update () {
		if (shipState.movement != Vector2.zero) {
			ship.transform.Translate (shipState.movement * Time.deltaTime);
			shipState.movement -= shipState.movement * Time.deltaTime;
			if (shipState.movement.magnitude < 0.01 && shipState.o < shipState.i) {
				shipState.movement = (Vector2) (shipState.positionQueue[shipState.o+1] - 
				                                shipState.positionQueue[shipState.o]);
				shipState.o++;
			}
		}
	}*/

	void OnMouseDown() {
		Debug.Log ("hit");
		if (!visited) {
			if (id == 0)
				shipState.endgame = true;
			stats.score += ship.GetComponent<RandomPlanets>().getDistance(shipState.currentPlanet, this.id);
			shipState.currentPlanet = this.id;


						visited = true;
						if (shipState.movementQueue.Count != 0) {
								Vector2[] destinations = (Vector2[])shipState.destinationQueue.ToArray ();
								shipState.movementQueue.Enqueue (this.transform.position - 
										(Vector3)destinations [shipState.movementQueue.Count - 1]);
						} else
								shipState.movementQueue.Enqueue (this.transform.position - (Vector3)shipState.destination);
						shipState.destinationQueue.Enqueue (this.transform.position);
				} else {
			Debug.Log ("youve already been here");
				}

		/*shipState.positionQueue [shipState.i++] = this.transform.position;
		if (shipState.o < shipState.i && shipState.movement == Vector2.zero) {
			shipState.movement = ((Vector2)shipState.positionQueue [shipState.i] - (Vector2)shipState.transform.position);
			shipState.o++;
		}
		shipState.i++;*/
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("collide");
		if (id == 0) {
			endGame();
				}
		}

	void endGame() {
		Application.LoadLevel ("endScreen");
	}

	public void setId(int id) {
		this.id = id;
	}
}