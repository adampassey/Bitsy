using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.UserInterface.Element {

	public static class Draggable {

		private static DraggedItem draggedItem;

		static Draggable() {
			draggedItem = DraggedItem.GetInstance();
		}
		/**
		 * 	Draw the specific inventory item
		 **/
		public static void Render(Rect position, GUIContent guiContent, GUIStyle guiStyle, DraggableHandler handler) {
			GUI.Box(position, guiContent, guiStyle);
			
			//	if the position of the current mouse event is within the rendering window
			if (position.Contains(UnityEngine.Event.current.mousePosition)) {

				//	trigger either Hover event
				if (draggedItem.item == null) {
					handler.Hover();
				} else {
					handler.Hover(draggedItem.item);
				}

				//	holding the item that will be dragged
				//	(if any)
				DraggableItem item = null;

				//	if a drag is initiated, notify the handler
				if (UnityEngine.Event.current.type == EventType.MouseDown && draggedItem.item == null) {
					item = handler.Drag();
					UnityEngine.Event.current.Use();
				}

				//	if a mouse up event happens, notify the handler
				//	whether or not there is an item being dragged
				if (UnityEngine.Event.current.type == EventType.MouseUp) {
					if (draggedItem.item == null) {
						item = handler.Click();
					} else {
						//	remove the dragged item if the handler returns true
						item = handler.ItemDropped(draggedItem.item);
						if (item != null) {
							draggedItem.item = item;
						} else {
							draggedItem.item = null;
						}
					}
					UnityEngine.Event.current.Use();
				}
				if (item != null) {
					draggedItem.item = item;
				}
			}
		}
	}

}