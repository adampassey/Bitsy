using UnityEngine;
using System.Collections;

using AdamPassey.Event;

public class EventUsage : MonoBehaviour
{
	//	Start
	void Start() {
		//	Use Events.When() to register event handlers
		//	to specific events.
		Events.When("some-event-happens", EventHandler);

		//	pausing for effect
		Invoke("FireListeners", 5f);

		//	check the console in this example
		Debug.Log("Event registered. Invoking event in 5 seconds.");
	}

	//	The event handler for "some-event-happens"
	public void EventHandler() {
		Debug.Log("Received event.");
	}

	//	Fires an event as an example
	private void FireListeners() {

		//	Fire an event- notifying all listeners
		Events.Fire("some-event-happens");
	}
}
