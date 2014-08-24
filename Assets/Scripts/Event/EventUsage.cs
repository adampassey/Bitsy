using UnityEngine;
using System.Collections;

using AdamPassey.Event;

public class EventUsage : MonoBehaviour {

	//	Start
	void Start() {
		//	Use Events.When() to register event handlers
		//	to specific events.
		Events.When("some-event-happens", EventHandler);
		Events.When("another-event-happens-send-myself", OtherEventHandler);

		//	pausing for effect
		Invoke("FireListeners", 5f);

		//	check the console in this example
		Debug.Log("Events registered. Invoking event in 5 seconds.");
	}

	//	The event handler for "some-event-happens"
	public void EventHandler(EventContext e) {
		Debug.Log("Received event: " + e.eventName);
	}

	//	The event handler for "another-event-happens-send-myself"
	public void OtherEventHandler(EventContext e) {
		Debug.Log("Received event: " + e.eventName);

		//	Watch out, sender 'can' be null
		if (e.sender != null) {
			Debug.Log("From sender: " + e.sender);
		}
	}

	//	Fires an event as an example
	private void FireListeners() {

		//	Fire an event- notifying all listeners
		Events.Fire("some-event-happens");

		//	Fire an event- notifying all listeners
		//	and passing this as sender
		Events.Fire("another-event-happens-send-myself", this);
	}
}
