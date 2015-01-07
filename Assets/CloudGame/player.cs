using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Sprite MainCharacter;
	public Vector2 direction;
	public float height;
	// Use this for initialization
	void Start () {
		height = 0;
		GetComponent<SpriteRenderer> ().sprite = MainCharacter;
	}
	
	// Update is called once per frame
	void Update () {

		//update the score to display the highest hight acheived
		if (transform.position.y > height)
						height = transform.position.y;
	}
}
