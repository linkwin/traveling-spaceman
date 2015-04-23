using UnityEngine;
using System.Collections;

public class paths : MonoBehaviour {
	
//	public randomnumber=0;
	// Input 0,1,2,3,4,0
	int[] Rearrange(int[] list2)
	{
		int length = list2.Length;
		Random rnd = new Random();
	//	int swap1 = rnd.Next(1,length);

		int swap1 = Random.Range (1, length-1);

		int swap2 = Random.Range (1, length-1);
		
		int swap1_value = list2 [swap1];
		//int swap2_value = list2 [swap2];
		list2 [swap1] =list2 [swap2] ;
		list2[swap2] = swap1_value;
		return list2;	
	}
	
	
	// array1 contains the distances between planets
	public int getPaths(int[][] array1)
	{
		int planets = array1.GetLength (0);
		int[] list2 = new int[planets+1]; 
		int[] list2_route1 = new int[planets+1];
		int[] list2_route2 = new int[planets+1];

		int index = 0;
		for (index =0; index <array1.GetLength (0); index++) {
			list2[index]=index;
		}
		list2[planets]=0;
		Debug.Log (planets);
		Debug.Log("Indexes");
		string listS = "";
		for(int item=0;item< list2.Length;item++)
			listS+=list2[item]+",";
		Debug.Log (listS);
		
		Debug.Log ("Test");
		list2_route1 = Rearrange (list2);
		int score1 = 0;
		int score2 = 0;
		string list1S="";
		string list2S="";
		for(int item=0; item<list2_route1.Length;item++)
			list1S+=list2_route1[item]+",";

		Debug.Log (list1S);
		for (int i=0; i<list2_route1.Length-1; i++) {
			score1 += array1[(int)list2_route1[i] ][(int)list2_route1[i+1]];
			Debug.Log (array1[(int)list2_route1[i] ][(int)list2_route1[i+1]]);
		}
		
		list2_route2 = Rearrange (list2);
		for (int i=0; i<list2_route1.Length-1; i++) {
			score2 += array1[(int) list2_route2[i] ][ (int)list2_route2[i+1]];
		}

		

		for(int item=0; item<list2_route2.Length;item++)
			list2S+=list2_route2[item]+",";
		Debug.Log (list2S);

		
		Debug.Log("Random");
		Debug.Log (Random.Range(0,6));
		Debug.Log ((score1 + score2)/2);
		string matrix = "";
		for (int i =0; i<array1.Length; i++) {
			for (int j =0; j<array1.Length; j++)
				matrix += array1 [i] [j]+",";
			matrix+="\n";
		}
		Debug.Log (matrix);
		return (score1 + score2) / 2;
	}
	
	// Use this for initialization
	void Start () {
		/*int[,] array = new int[5, 5];
		for (int i=0; i<5; i++)
						for (int j=0; j<5; j++) {
								// Contains Distances
								if (i == j) {
										array [i, j] = 0;
								} else {
										array [i, j] = Random.Range (100, 800);
								}
						}
		Debug.Log ("Inside Start");
		//				}*/
		//RandomPlanets randomPlanets = GetComponent<RandomPlanets> ();
		//int[][] distanceMatrix = randomPlanets.getDistanceMatrix ();
		//getPaths (distanceMatrix);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
