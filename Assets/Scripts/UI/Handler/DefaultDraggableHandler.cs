using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface.Handler {

	/**
	 * 	When the mouse hovers over a UI.Draggable, this
	 * 	abstract class will be responsible for focusing
	 * 	on the parent window.
	 * 
	 **/
	public abstract class DefaultDraggableHandler : DraggableHandler {

		private GameObject window;

		public DefaultDraggableHandler(GameObject window) {
			this.window = window;
		}

		public void Hover() {
			
		}
		
		public void Hover(DraggableItem item) {
			GUI.FocusWindow(window.GetInstanceID());
		}

		public abstract DraggableItem Drag();

		public abstract DraggableItem Click();

		public abstract DraggableItem ItemDropped(DraggableItem item);
	}
}
