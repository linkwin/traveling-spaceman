using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timer : MonoBehaviour {
	public Text txt;
	float timeLeft = 90f;
	// Use this for initialization
	void Start () {
		//txt = gameObject.GetComponent<Text> ();
		timeLeft = timeLeft-Time.deltaTime;
		txt.text = timeLeft.ToString("R");

	}
	
	// Update is called once per frame
	void Update () {

		timeLeft = timeLeft-Time.deltaTime;
		txt.text = timeLeft.ToString("R");
		if (timeLeft < 0) {
			//Debug.Log("hello");
			//endcanvas.enabled = true;
			//txt.text = "Game Over";
			timeLeft = 90f;
			txt.text = timeLeft.ToString("R");
			Application.LoadLevel("endScreen");
		} 
		
		
		
	}
	
}