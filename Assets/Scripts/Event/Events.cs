using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Bitsy.Util;

namespace Bitsy.Event {

	public static class Events {

		private static Dictionary<string, Action<EventContext>> listeners;
		private static CoroutineDispatcher coroutineDispatcher = CoroutineDispatcher.GetInstance();

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
			coroutineDispatcher.DispatchCoroutine(FireCoroutine(eventName, null));
		}

		/**
		 * Fire an event, passing sender to listeners.
		 * 
		 * @param string eventName The name of the event to fire.
		 * @param object sender The object to pass to the listener.
		 * 
		 **/
		public static void Fire(string eventName, UnityEngine.Object sender) {
			coroutineDispatcher.DispatchCoroutine(FireCoroutine(eventName, sender));
		}

		/**
		 * Fires off the event as a Coroutine.
		 * 
		 * @param string eventName The name of the event to fire.
		 * @param object sender The object to pass to the listener.
		 **/
		private static IEnumerator FireCoroutine(string eventName, UnityEngine.Object sender) {
			foreach (KeyValuePair<string, Action<EventContext>> entry in listeners) {
				if (entry.Key == eventName) {
					
					EventContext e = new EventContextImpl();
					e.eventName = eventName;	
					e.sender = sender;
					
					entry.Value(e);
				}

				yield return null;
			}
		}
	}
}
