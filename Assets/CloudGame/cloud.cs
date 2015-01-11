using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {
	public bool good;
	public Vector3 force;
	public GameObject player;

	public PhysicMaterial bouncy;
	public PhysicMaterial notBouncy;
	// Use this for initialization
	void Start () {
		good = true;
		force = new Vector3 (0,1,0);

		if (good)
						GetComponent<BoxCollider> ().material = bouncy;
				else
						GetComponent<BoxCollider> ().material = notBouncy;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > transform.position.y)
						GetComponent<BoxCollider> ().enabled = true;

	}
}
