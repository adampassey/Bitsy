using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface.Handler {

	/**
	 * 	A DraggableHandler will receive events from UI.Draggable elements
	 **/
	public interface DraggableHandler {

		void Hover();

		void Hover(DraggableItem item);

		//	return a DraggableItem to start dragging it
		DraggableItem Drag();

		//	return a DraggableItem to start dragging it
		DraggableItem Click();

		//	return a DraggableItem to start dragging it
		DraggableItem ItemDropped(DraggableItem item);
	}
}
