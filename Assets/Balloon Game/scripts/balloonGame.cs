using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class balloonGame : MonoBehaviour {

	public GameObject balloon;

	public Sprite goodballoon;
	public Sprite badballoon;

	public Transform canvas;

	float lastBallonX;
	float count;
	// Use this for initialization
	void Start () {
		count = 700;
	}
	
	// Update is called once per frame
	void Update () {

		if (count == 1000) {
			int temp = Random.Range (1,4);
			for (int x = 0;x<=temp;x++)
			{
				SpawnBalloon();
			}
			count = 0;
				}

		count++;
	}

	void SpawnBalloon(){
		GameObject newBalloon = balloon;
		Instantiate (newBalloon);
		int temp = Random.Range (-100, 101);
		while (temp  - lastBallonX > -20 && temp - lastBallonX < 20)
						temp = Random.Range (-100, 101);

		lastBallonX = temp;
		newBalloon.GetComponent<ballon> ().directionX = temp;
		float rand = Random.Range (1, 4);
		if (rand == 1) 
		{
						newBalloon.GetComponent<ballon> ().good = true;
						newBalloon.GetComponent<SpriteRenderer> ().sprite = goodballoon;
				}
		else
		{
						newBalloon.GetComponent<ballon> ().good = false;
						newBalloon.GetComponent<SpriteRenderer> ().sprite = badballoon;
		}



	}
}
