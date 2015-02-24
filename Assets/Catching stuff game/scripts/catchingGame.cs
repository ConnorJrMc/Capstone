using UnityEngine;
using System.Collections;

public class catchingGame : MonoBehaviour {

	public GameObject stuff;
	public float count;
	public float height;
	public float width;
	// Use this for initialization
	void Start () {
		count = 0;

		//setup camera info
		Camera cam = Camera.main;
		Vector3 p1 = cam.ViewportToWorldPoint(new Vector3(0,0,cam.nearClipPlane));
		Vector3 p2 = cam.ViewportToWorldPoint(new Vector3(1,0,cam.nearClipPlane));
		Vector3 p3 = cam.ViewportToWorldPoint(new Vector3(1,1,cam.nearClipPlane));

		width = (p2 - p1).magnitude;
		height = (p3 - p2).magnitude;
	}
	
	// Update is called once per frame
	void Update () {


		if (count == 60) {

			float temp  = Random.Range (0,2);
			if(temp == 0)
				SpawnStuff (false);
			else
				SpawnStuff (true);

			count =0;
				}

		count++;
	}

	void SpawnStuff(bool good){

		GameObject thing = stuff;
		Instantiate (thing);
		//make the cloud the new distance away 
		Vector3 newPosition = new Vector3 (0, 0, 0);
		float Max = width;
		//x value is a random number within the screen
		float temp = Random.Range (0, Max);

		//Debug.Log (temp);
		Vector3 holder = Camera.main.ViewportToWorldPoint(new Vector3(temp,0,-4));

		newPosition.x = holder.x;
		newPosition.y = holder.y * 2;
		newPosition.z = -4.0f;

		thing.transform.position = newPosition;
		thing.GetComponent<fallingStuff> ().good = good;

	}
}
