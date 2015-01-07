using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	protected CharacterController control;
	public float moveSpeed;

	protected Vector3 move = Vector3.zero;
	// Use this for initialization
	public virtual void Start () {

		control = GetComponent<CharacterController> ();			

			//error checking
			if (!control) {
				Debug.LogError(name + "has no character controller");
				enabled = false;
			}
		}
	// Update is called once per frame
	public virtual void Update () {

		//rotation
		transform.LookAt (((move*5) + transform.position));
		//movement
		control.SimpleMove (move * moveSpeed);
	}
}
