using UnityEngine;
using System.Collections;

public class characterFollow : MonoBehaviour {

	public GameObject target;
	public bool hasTarget;
	// Update is called once per frame
	void Start(){
		hasTarget = false;
	}

	void Update () {
		if (!hasTarget) {
			target = GameObject.FindGameObjectWithTag ("Player");
			//transform.LookAt (target.transform.position);
			hasTarget = true;
		}
		else
			transform.position = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z - 0.4f);
	}
}
