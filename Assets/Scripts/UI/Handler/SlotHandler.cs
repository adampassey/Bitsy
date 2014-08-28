using UnityEngine;
using System.Collections;

namespace Bitsy.UserInterface.Handler {

	/**
	 * 	A SlotHandler will receive events from UI.Slot elements
	 * 
	 **/
	public interface SlotHandler {

		void Hover();

		//	return a DraggableItem to consume the draggable item
		bool ItemDropped(DraggableItem item);

	}
}
