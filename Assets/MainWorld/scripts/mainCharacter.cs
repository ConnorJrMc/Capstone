using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainCharacter: character {
	
	protected bool up;
	protected bool down;
	protected bool left;
	protected bool right;

	public Camera cam;


	// Use this for initialization
	public override void Start () {
		base.Start();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	public override void Update () {

		moveFunction (up, down, left, right);
		move.Normalize ();
		base.Update ();
		move.Set (0, 0, 0);
		cam.transform.position.Set (1, 1, 1);

	}

	private void moveFunction(bool u,bool d, bool l, bool r)
	{
		if (u)
						move.z = 1;
		if (d)
						move.z = -1;
		if (l)
						move.x = -1;
		if (r)
						move.x = 1;
		}

	public void MoveUp()
	{
		up = true;
	}

	public void MoveUpStop()
	{
		up = false;
	}

	public void MoveDown()
	{
		down = true;
	}

	public void MoveDownStop()
	{
		down = false;
	}

	public void MoveLeft()
	{
		left = true;
	}
	public void MoveLeftStop()
	{
		left = false;
	}

	public void MoveRight()
	{
		right = true;	
	}

	public void MoveRightStop()
	{
		right = false;
	}
}
