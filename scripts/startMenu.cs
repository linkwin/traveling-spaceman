using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour {
	public void loadGame () {

		Application.LoadLevel (Application.loadedLevelName);

	}
}
