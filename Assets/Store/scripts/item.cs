using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class item : MonoBehaviour {

	public int cost;
	public string id;
	public Sprite sprite;
	public Sprite bought;

	// Use this for initialization
	void Start () {
		if(sprite !=null)
		GetComponent<Image> ().sprite = sprite;

		id = sprite.name;

		GetComponentInChildren<Text> ().text = cost.ToString ();
	}


	//when the button is clicked
	void OnClick()
	{
		int temp = PlayerPrefs.GetInt ("score");
		if (temp >= cost) {
			//purchase the item
			temp = temp - cost;
			PlayerPrefs.SetInt("score",temp);

			//add the item to inventory

			//add show the item as bought
			if(bought !=null)
			GetComponent<Image>().sprite = bought;
				}
	}
}
