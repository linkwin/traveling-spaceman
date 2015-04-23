using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Point
{
	public int x;
	public int y;

	public Point(int Xcoordinate,int Ycoordinate){
		x = Xcoordinate;
		y = Ycoordinate;
	}

	public int Distance(Point other){
		float x1 = (float)this.x;
		float y1 = (float)this.y;
		float x2 = (float)other.x;
		float y2 = (float)other.y;
		int dist = (int)Mathf.Sqrt(Mathf.Pow(x1-x2, 2)+Mathf.Pow(y1-y2, 2));
		return dist;
	}
}

public class RandomPlanets : MonoBehaviour {

	private List<Point> planetCoordinates;

	private int[][] distanceMatrix;

	public GameObject planet;

	public Sprite[] planetSprites;

	public int xRange = 23;
	public int yRange = 9;
	public GameObject canvas;
	public static int path;

	// Use this for initialization
	void Start () {
		int planet_number = 5;
		List<Point> PlanetCoordinates = new List<Point>();
		PlanetCoordinates.Add(new Point(Random.Range (-xRange, xRange),Random.Range (-yRange, yRange)));
		int Count = 1;
		while (Count != planet_number) {
			Point randc = new Point(Random.Range (-xRange, xRange),Random.Range (-yRange, yRange));
			int t = 0;
			for(int i = 0; i < PlanetCoordinates.Count; i++){
				if (PlanetCoordinates[i].Distance(randc) >= 10){
					t++;
				}
			if (t == PlanetCoordinates.Count){
					PlanetCoordinates.Add(randc);
					Count++;
					}
				}
			}

		int[][] DistanceMatrix = new int[planet_number][];

		for (int j=0; j <= planet_number-1; j++) {
			DistanceMatrix[j] = new int[planet_number];
			for (int k=0; k <= planet_number-1; k++) {
				int distance = PlanetCoordinates[j].Distance(PlanetCoordinates[k]);
				Debug.Log (PlanetCoordinates[j].x+","+PlanetCoordinates[j].y + " --> "+ PlanetCoordinates[k].x+","+
				           PlanetCoordinates[k].y + " is " + distance+"m" + "away");
				DistanceMatrix[j][k] = distance;
			}
		}

		//pass to path algorithm
		string matrix = "";
		for (int i =0; i<DistanceMatrix.Length; i++) {
			for (int j =0; j<DistanceMatrix.Length; j++)
				matrix += DistanceMatrix [i] [j]+",";
			matrix+="\n";
		}
		distanceMatrix = (int[][])DistanceMatrix.Clone();
		paths pathAlg = GetComponent<paths> ();

		path = pathAlg.getPaths (distanceMatrix);

		Debug.Log (matrix);

		Camera camera = Camera.main;
		int p = 0;//counter
		//instatiate planets
		PlanetCoordinates.ForEach(delegate(Point point) {
			if (p == 0) {
				this.transform.Translate (new Vector3(point.x, point.y, -6f)-transform.position);
				GetComponent<ShipState>().end = new Vector2(point.x, point.y);
			}
			GameObject planetObject = (GameObject)Instantiate(planet, new Vector3(point.x, point.y, 0), transform.rotation);
			GameObject coord = (GameObject)Instantiate(canvas, new Vector3(point.x, point.y-3, 0), transform.rotation);
			//Canvas theCanvas = GameObject.Find ("Canvas");
			Text text = coord.GetComponentInChildren<Text>();
			text.text = point.x + ", " + point.y;
			Vector3 pos = camera.WorldToScreenPoint(new Vector3(point.x,point.y,0)+new Vector3(-19,-15,0));
			text.rectTransform.localPosition = pos;
			planetObject.GetComponent<SpriteRenderer>().sprite = planetSprites[p];
			planetObject.GetComponent<MainController>().setId(p);
			planetObject.GetComponent<CircleCollider2D>().radius = 4.25f;//TODO make this function of number of planets
			p++;
		});
		Debug.Log ("random planets finished");
	}

	public int[][] getDistanceMatrix() {
				return distanceMatrix;
		}
	public int getDistance(int from, int to) {
		return distanceMatrix[from][to];
	}
}
