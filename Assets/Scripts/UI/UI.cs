using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.UserInterface.Element;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.UserInterface {

	public static class UI {

		/**
		 *	Draw a UI Draggable Element
		 *	@param Rect position The position to render the element
		 *	@param GUIContent guiContent The GUIContent of this element
		 *	@param GUIStyle guiStyle The GUIStyle
		 *	@param DraggableHandler handler The handler that receives the click
		 *		and drag events
		 **/
		public static void Draggable(Rect position, GUIContent guiContent, GUIStyle guiStyle, DraggableHandler handler) {
			Element.Draggable.Render(position, guiContent, guiStyle, handler);
		}

		/**
		 * 	Draw a UI Slot (receives drag-and-drop events)
		 * 	@param Rect position The position to render the element
		 * 	@param GUIStyle guiStyle The GUIStyle
		 * 	@param SlotHandler handler The handler that receives the drop
		 * 		and hover events
		 **/
		public static void Slot(Rect position, GUIStyle guiStyle, SlotHandler handler) {
			Element.Slot.Render(position, guiStyle, handler, new GUIContent());
		}

		public static void Slot(Rect position, GUIStyle guiStyle, SlotHandler handler, GUIContent guiContent) {
			Element.Slot.Render(position, guiStyle, handler, guiContent);
		}
		
	}
}