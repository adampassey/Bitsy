using System;
using System.Collections.Generic;

namespace AdamPassey.Event {

	public static class Events {

		public static Dictionary<string, Action<EventContext>> listeners;

		/**
		 * Static constructor
		 * Instantiate a dictionary to hold listeners
		 **/
		static Events() {
			listeners = new Dictionary<string, Action<EventContext>>();
		}

		/**
		 * Attach an event to a specific action.
		 * 
		 * @param string eventName The name of the event to fire
		 * @param Action method The method to fire
		 **/ 
		public static void When(string eventName, Action<EventContext> method) {
			listeners.Add(eventName, method);
		}

		/**
		 * Fire an event.
		 * 
		 * @param string eventName The name of the event to fire.
		 **/
		public static void Fire(string eventName) {
			Fire(eventName, null);
		}

		/**
		 * Fire an event, passing sender to listeners.
		 * 
		 * @param string eventName The name of the event to fire.
		 * @param object sender The object to pass to the listener.
		 * 
		 **/
		public static void Fire(string eventName, Object sender) {
			foreach (KeyValuePair<string, Action<EventContext>> entry in listeners) {
				if (entry.Key == eventName) {

					EventContext e = new EventContextImpl();
					e.eventName = eventName;	
					e.sender = sender;
					
					entry.Value(e);
				}
			}
		}
	}
}
