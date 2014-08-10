using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.UserInterface.Element
{
	public static class Slot
	{
		/**
		 * 	Draw an open inventory slot
		 **/
		public static void Render(Rect position, GUIStyle guiStyle, SlotHandler handler) {
			//	create the rendering rect to serve as the rendering position 
			//	and the event-receiving area
			GUI.Box(position, "", guiStyle);
			
			//	if the mouse is over this element
			if (position.Contains(UnityEngine.Event.current.mousePosition)) {

				//	fire the hover event on the handler
				handler.Hover();

				//	fire the mouse-up event on the handler
				if (UnityEngine.Event.current.type == EventType.MouseUp) {
					handler.MouseUp(UnityEngine.Event.current);
				}
			}
		}
	}
}
