using System;

namespace AdamPassey.Event {

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

