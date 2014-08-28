using UnityEngine;
using System.Collections;

namespace Bitsy.UserInterface.Handler {

	/**
	 * 	When the mouse hovers over a UI.Slot, this
	 * 	abstract class will be responsible for focusing
	 * 	on the parent window.
	 * 
	 **/
	public abstract class DefaultSlotHandler : SlotHandler {

		private GameObject window;

		public DefaultSlotHandler(GameObject window) {
			this.window = window;
		}

		public void Hover() {
			GUI.FocusWindow(window.GetInstanceID());
		}
		
		//	return a DraggableItem to consume the draggable item
		public abstract bool ItemDropped(DraggableItem item);

	}
}
