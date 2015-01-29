using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class rope : MonoBehaviour {

	public int Score;
	public GameObject CurrentScore;

	// Use this for initialization
	void Start () {
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//upon a complete rotation
		Score++;
		//CurrentScore.GetComponent<Text> ().text = Score.ToString ();
	}
}
