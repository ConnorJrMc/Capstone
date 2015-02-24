using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class balloonScore : MonoBehaviour {

	public float totalScore;
	// Use this for initialization
	void Start () {
		totalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = totalScore.ToString();
	}
}
