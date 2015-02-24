using UnityEngine;
using System.Collections;

public class fallingStuff : MonoBehaviour {

	public bool good;
	public float weight;
	public GameObject player;

	public Texture GoodStuff;
	public Texture badStuff;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody> ().mass = weight;
		player = GameObject.FindGameObjectWithTag("Player");

		if (good)
						renderer.material.mainTexture = GoodStuff;
		else
			renderer.material.mainTexture  = badStuff;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -4)
						Destroy (gameObject);
	}

	void OnTriggerEnter(Collider col)
	{		
		if (col.tag == "Player") {
			//if the object is good give points
			if(good)
				player.GetComponent<catchingPlayer>().score++;
			//if the object is bad remove health
			if(!good)
				player.GetComponent<catchingPlayer>().health--;

			Destroy (gameObject);
		}			
	}
}
