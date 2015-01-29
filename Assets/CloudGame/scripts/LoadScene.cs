using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public string scene;
	// Use this for initialization
	public void loadScene()
	{
		Application.LoadLevel (scene);
	}
}
