using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dpad : MonoBehaviour {
	// Use this for initialization
	public GameObject Up;
	public GameObject Down;
	public GameObject Left;
	public GameObject Right;

	public GameObject Player;
	public delegate void EventDelegate(UnityEngine.EventSystems.BaseEventData baseEvent);

	//up methods
	public void UpDown(UnityEngine.EventSystems.BaseEventData baseEvent){
				Player.GetComponent<mainCharacter> ().MoveUp ();
		}

	public void UpUp(UnityEngine.EventSystems.BaseEventData baseEvent){
				Player.GetComponent<mainCharacter> ().MoveUpStop ();
		}

	//down methods
	public void DownDown(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveDown ();
	}
	
	public void DownUp(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveDownStop ();
	}

	//RIGHT methods
	public void RightDown(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveRight ();
	}
	
	public void RightUp(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveRightStop ();
	}

	//LEFT methods
	public void LeftDown(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveLeft ();
	}
	
	public void LeftUp(UnityEngine.EventSystems.BaseEventData baseEvent){
		Player.GetComponent<mainCharacter> ().MoveLeftStop ();
	}

	void Start () {

				//for each button in the dpad

				//UP BUTTON
		{
				EventTrigger trigger = Up.GetComponent<EventTrigger> ();

				EventTrigger.Entry entry = new EventTrigger.Entry ();
				//the new event is of pointerDown type
				entry.eventID = EventTriggerType.PointerDown;
				entry.callback = new EventTrigger.TriggerEvent ();
				//create a new unity action, that contrains the onPointerDown method delage to respond to events
				UnityEngine.Events.UnityAction<BaseEventData> callback = 
				new UnityEngine.Events.UnityAction<BaseEventData> (UpDown);

				entry.callback.AddListener (callback);
				trigger.delegates.Add (entry);


				//point up
				EventTrigger.Entry entry1 = new EventTrigger.Entry ();
				entry1.eventID = EventTriggerType.PointerUp;
				entry1.callback = new EventTrigger.TriggerEvent ();
				//create a new unity action, that contrains the onPointerDown method delage to respond to events
				callback = new UnityEngine.Events.UnityAction<BaseEventData> (UpUp);
			
				entry1.callback.AddListener (callback);
				trigger.delegates.Add (entry1);
		}
	
		//DOWN BUTTON
		{
				EventTrigger trigger = Down.GetComponent<EventTrigger> ();
	
				EventTrigger.Entry entry = new EventTrigger.Entry ();
				//the new event is of pointerDown type
				entry.eventID = EventTriggerType.PointerDown;
				entry.callback = new EventTrigger.TriggerEvent ();
				//create a new unity action, that contrains the onPointerDown method delage to respond to events
				UnityEngine.Events.UnityAction<BaseEventData> callback = 
				new UnityEngine.Events.UnityAction<BaseEventData> (DownDown);
		
				entry.callback.AddListener (callback);
				trigger.delegates.Add (entry);
		
		
				//point up
				EventTrigger.Entry entry1 = new EventTrigger.Entry ();
				entry1.eventID = EventTriggerType.PointerUp;
				entry1.callback = new EventTrigger.TriggerEvent ();
				//create a new unity action, that contrains the onPointerDown method delage to respond to events
				callback = new UnityEngine.Events.UnityAction<BaseEventData> (DownUp);
		
				entry1.callback.AddListener (callback);
				trigger.delegates.Add (entry1);
		}

		//RIGHT BUTTON
		{
			EventTrigger trigger = Right.GetComponent<EventTrigger> ();
			
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			//the new event is of pointerDown type
			entry.eventID = EventTriggerType.PointerDown;
			entry.callback = new EventTrigger.TriggerEvent ();
			//create a new unity action, that contrains the onPointerDown method delage to respond to events
			UnityEngine.Events.UnityAction<BaseEventData> callback = 
				new UnityEngine.Events.UnityAction<BaseEventData> (RightDown);
			
			entry.callback.AddListener (callback);
			trigger.delegates.Add (entry);
			
			
			//point up
			EventTrigger.Entry entry1 = new EventTrigger.Entry ();
			entry1.eventID = EventTriggerType.PointerUp;
			entry1.callback = new EventTrigger.TriggerEvent ();
			//create a new unity action, that contrains the onPointerDown method delage to respond to events
			callback = new UnityEngine.Events.UnityAction<BaseEventData> (RightUp);
			
			entry1.callback.AddListener (callback);
			trigger.delegates.Add (entry1);
		}

		//LEFT BUTTON
		{
			EventTrigger trigger = Left.GetComponent<EventTrigger> ();
			
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			//the new event is of pointerDown type
			entry.eventID = EventTriggerType.PointerDown;
			entry.callback = new EventTrigger.TriggerEvent ();
			//create a new unity action, that contrains the onPointerDown method delage to respond to events
			UnityEngine.Events.UnityAction<BaseEventData> callback = 
				new UnityEngine.Events.UnityAction<BaseEventData> (LeftDown);
			
			entry.callback.AddListener (callback);
			trigger.delegates.Add (entry);
			
			
			//point up
			EventTrigger.Entry entry1 = new EventTrigger.Entry ();
			entry1.eventID = EventTriggerType.PointerUp;
			entry1.callback = new EventTrigger.TriggerEvent ();
			//create a new unity action, that contrains the onPointerDown method delage to respond to events
			callback = new UnityEngine.Events.UnityAction<BaseEventData> (LeftUp);
			
			entry1.callback.AddListener (callback);
			trigger.delegates.Add (entry1);
		}
	
	}


	public void GetPlayer()
	{
		Player = GameObject.FindGameObjectWithTag("Player");

		if (!Player) {
			Debug.LogError("Player could no be found");
		}
	}
}
