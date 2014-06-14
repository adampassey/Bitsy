using System;
using System.Collections.Generic;

namespace AdamPassey.Event
{
	public static class Events
	{
		public static Dictionary<string, Action> listeners;

		/**
		 * Static constructor
		 * Instantiate a dictionary to hold listeners
		 **/
		static Events()
		{
			listeners = new Dictionary<string, Action>();
		}

		/**
		 * Attach an event to a specific action.
		 * 
		 * @param string eventName The name of the event to fire
		 * @param Action method The method to fire
		 **/ 
		public static void When(string eventName, Action method) {
			listeners.Add(eventName, method);
		}

		/**
		 * Fire an event.
		 * 
		 * @param string eventName The name of the event to fire.
		 **/
		public static void Fire(string eventName) {
			foreach (KeyValuePair<string, Action> entry in listeners) {
				if (entry.Key == eventName) {
					//	TODO: send an Event object to receiver
					entry.Value();
				}
			}
		}
	}
}
