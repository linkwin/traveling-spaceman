using UnityEngine;
using System.Collections;

public class showLine : MonoBehaviour {

	ArrayList objects = new ArrayList();

	public GameObject lineRender; 
	public LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {

	}

	void drawLines (){
		//DrawLines
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (0.1f, 0.2f);
		lineRenderer.SetVertexCount (objects.Count);

		for (int i= 0; i<objects.Count; i++) {
			GameObject cobject = (GameObject)objects [i];
			lineRenderer.SetPosition (i, new Vector3 (cobject.transform.position.x, cobject.transform.position.y, cobject.transform.position.z));
			
		}
		lineRender.SetActive(true);
	}

	public void addPlanet(GameObject planet) {
		objects.Add (planet);
		}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			this.drawLines();
		
			}
		if (Input.GetMouseButtonUp (1)) {
			lineRenderer.SetVertexCount(0);
				}
						
			}

}
