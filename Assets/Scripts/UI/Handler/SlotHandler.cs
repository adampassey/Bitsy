using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface.Handler
{
	/**
	 * 	A SlotHandler will receive events from UI.Slot elements
	 * 
	 **/
	public interface SlotHandler
	{
		void Hover();

		void MouseUp(UnityEngine.Event e);

	}
}
