using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cloudGame : MonoBehaviour {

	//distance between clouds
	public float cloudMinimum;

	//angle to spawn clouds in
	float thetaMin = 20;
	float thetaMax = 60;

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
		for (int x = 1; x<15; x++)
						makeCloud (true, clouds [x - 1].transform.position, x);
	}
	
	// Update is called once per frame
	void Update () {
	
		//spawn a good cloud at this distance away from the last added cloud
		for (int x = 0; x<clouds.Count; x++) {
			//update the cloud id's 
			clouds[x].GetComponent<cloud>().cloudID = x;
			if(clouds[x].transform.position.y > Player.transform.position.y)
				clouds[x].GetComponent<BoxCollider>().enabled = true;
				}

		//if there is less than the number of clouds desired at once
		if (clouds.Count < numClouds) {
			//make more clouds
			makeCloud(true,clouds[clouds.Count - 1].transform.position,clouds.Count);
				}
		//clouds will only spawn a minimum distance away from other clouds

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

		//find new position between theta, at cloud minimum distance away for the new cloud
		float temp = Random.Range (thetaMin, thetaMax);

		//adjust cloud position along x axis to keep it on the screen

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
		NewCloud.transform.position = new Vector3 (0.0f, -3.5f, 0.0f);
		NewCloud.GetComponent<cloud> ().cloudID = 0;
		clouds.Add (NewCloud);
		Instantiate (NewCloud);
	}
}

