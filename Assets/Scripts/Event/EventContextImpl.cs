using System;

namespace Bitsy.Event {
	/**
	 * Implementation of EventContext that will be sent
	 * to event listeners.
	 * 
	 **/
	public class EventContextImpl : EventContext {
		public Object sender { get; set; }
		public string eventName { get; set; }
	}
}