using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cloudGame : MonoBehaviour {

	//distance between clouds
	public float cloudMinimum;

	//angle to spawn clouds in
	float Min = 0;
	float Max = Screen.width;

	//number of clouds at once
	public int numClouds;
	//will update so that a good cloud is always within jumping distance
	public float distanceFromGoodCloud;


	public GameObject Player;
	public GameObject Cloud;
	public List<GameObject> clouds = new List<GameObject>();
	// Use this for initialization
	void Start () {
		numClouds = 15;
		Player = GameObject.FindGameObjectWithTag ("Player");
		cloudMinimum = 3;

		makeFirstCloud (true);
		for (int x = 1; x<1; x++)
						makeCloud (true, clouds [x - 1].transform.position, x);
	}
	
	// Update is called once per frame
	void Update () {
	
		//spawn a good cloud at this distance away from the last added cloud
		for (int x = 0; x<clouds.Count; x++) {
			//update the cloud id's 
			clouds[x].GetComponent<cloud>().cloudID = x;
				}

		//if there is less than the number of clouds desired at once
		if (clouds.Count < numClouds) {
			//make more clouds
			makeCloud(true,clouds[clouds.Count - 1].transform.position,clouds.Count);
				}

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("pause screen here");
		}
	}
	//function to create clouds
	public void makeCloud(bool type, Vector3 lastCloud, int id)
	{
		GameObject NewCloud = Cloud;
		//each good cloud increases the chance for the next one to be bad
		//each bad cloud increases the chance for the next one to be good
		//this value is decreased relative to height, the higher you are the more bad clouds
		NewCloud.GetComponent<cloud> ().good = type;

		//make the cloud the new distance away 
		Vector3 newPosition = lastCloud;
		newPosition.y += cloudMinimum;

		//x value is a random number within the screen
		float temp = Random.Range (Min, Max);
		Vector3 holder = Camera.main.ScreenToWorldPoint(new Vector3(temp,0,0));
		newPosition.x = holder.x;
	
		NewCloud.GetComponent<cloud> ().cloudID = id;
		NewCloud.transform.position = newPosition;
		NewCloud.GetComponent<cloud> ().player = Player;
		clouds.Add (NewCloud);
		Instantiate (NewCloud);
	}
	public void makeFirstCloud(bool type)
	{
		GameObject NewCloud = Cloud;
		NewCloud.GetComponent<cloud> ().good = type;
		NewCloud.transform.position = new Vector3 (0, 0, 0);
		NewCloud.GetComponent<cloud> ().cloudID = 0;
		NewCloud.GetComponent<cloud> ().player = Player;
		clouds.Add (NewCloud);
		Instantiate (NewCloud);
	}

	public void OnMouseDown()
	{
		Application.LoadLevel ("cloudMenu");
		}
}


