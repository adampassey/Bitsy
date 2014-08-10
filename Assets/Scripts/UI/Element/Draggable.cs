using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.UserInterface.Element
{
	public static class Draggable
	{
		/**
		 * 	Draw the specific inventory item
		 **/
		public static void Render(Rect position, GUIContent guiContent, GUIStyle guiStyle, DraggableHandler handler) {
			GUI.Box(position, guiContent, guiStyle);
			
			//	if the position of the current mouse event is within the rendering window
			if (position.Contains(UnityEngine.Event.current.mousePosition)) {

				if (UnityEngine.Event.current.type == EventType.MouseDrag) {
					handler.MouseDrag(UnityEngine.Event.current);
				}

				if (UnityEngine.Event.current.type == EventType.MouseUp) {
					handler.MouseUp(UnityEngine.Event.current);
				}
			}
		}
	}

}