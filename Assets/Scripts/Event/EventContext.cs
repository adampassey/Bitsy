using System;

namespace Bitsy.Event {

	/**
	 * Interface for object that will be sent to 
	 * event listeners.
	 * 
	 **/
	public interface EventContext {
		string eventName { get; set; }
		Object sender { get; set; }
	}
}

