using System;

namespace AdamPassey.Event
{
	public class EventImpl : Event
	{
		private Object sender;

		public Object Sender {
			get { return sender; }
			set { sender = value; }
		}

	}
}