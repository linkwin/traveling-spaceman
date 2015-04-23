using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text box;

	// Use this for initialization
	void Start () {
		int score = MainController.displayScore;
		box.GetComponent<Text> ().text += "Distance traveled: " + MainController.displayScore + " Light Years";
		int path = RandomPlanets.path;
		box.GetComponent<Text> ().text += "\nOptimal path distance: "+path+" Light Years";
		if (score <= path)
			box.GetComponent<Text> ().text += "\nCongratulations! You have traveled a better path.";
				else
						box.GetComponent<Text> ().text += "\nToo long! Better luck next time!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
