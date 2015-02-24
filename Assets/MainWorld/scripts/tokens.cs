using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class tokens : MonoBehaviour {

	public int score;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("score");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("score",score);
		GetComponent<Text> ().text = score.ToString();
	}
}
