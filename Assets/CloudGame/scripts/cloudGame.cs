using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cloudGame : MonoBehaviour {

	public float cloudRange;
	public float cloudMinimum;


	public GameObject Player;
	public GameObject Cloud;
	public List<GameObject> clouds = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		cloudMinimum = 3;
		//area that clouds can spawn in start equal to the minimum distance apart
		cloudRange = cloudMinimum;

		makeFirstCloud (true);
	}
	
	// Update is called once per frame
	void Update () {
	
		//cloud range is  porportional to player height, higher the player is the greater the distance between teh next cloud is
		cloudRange = Player.GetComponent<player> ().height + cloudMinimum;
		//cap the range so that it is still possible to play
		if (cloudRange > 5)
						cloudRange = 5;
		//spawn a good cloud at this distance away from the last added cloud

		//clouds will only spawn a minimum distance away from other clouds
		makeCloud (true, clouds [clouds.Count - 1].transform.position);

	}
	//function to create clouds
	public void makeCloud(bool type, Vector3 lastCloud)
	{
		GameObject NewCloud = Cloud;
		NewCloud.GetComponent<cloud> ().good = type;

		//make the cloud the new distance away 
		Vector3 newPostion = lastCloud.normalized * cloudRange;

		NewCloud.transform.position = newPostion;
		clouds.Add (NewCloud);
		Instantiate (NewCloud);
	}
	public void makeFirstCloud(bool type)
	{
		GameObject NewCloud = Cloud;
		NewCloud.GetComponent<cloud> ().good = type;
		//NewCloud.transform.position.Set (0, -3.5, 0);
		clouds.Add (NewCloud);
		Instantiate (NewCloud);
	}
}

