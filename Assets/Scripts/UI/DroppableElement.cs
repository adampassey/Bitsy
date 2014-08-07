using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.UserInterface
{
	public static class DroppableElement
	{
		private static DraggedItem draggedItem;
		
		static DroppableElement()
		{
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	Draw an open inventory slot
		 **/
		public static void Render(InventoryPosition position, Vector2 guiPosition, int tilesize, GameObject[,] inventory, GameObject window) {
			
			//	create the rendering rect to serve as the rendering position 
			//	and the event-receiving area
			Rect renderingRect = new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize);
			GUI.Box(renderingRect, "");
			
			//	if the mouse is over this element
			if (renderingRect.Contains(UnityEngine.Event.current.mousePosition)) {
				
				//	if something is being dragged, focus the window-
				//	otherwise the mouseUp event doesn't propagate through
				if (draggedItem.item != null) {
					GUI.FocusWindow(window.GetInstanceID());
				}
				
				//	if there's a mouseUp event on this slot, drop the dragged item on it
				if (UnityEngine.Event.current.type == EventType.MouseUp && draggedItem.item != null) {
					inventory[position.x, position.y] = draggedItem.item.gameObject;
					draggedItem.item = null;
					UnityEngine.Event.current.Use();
				}
			}
		}
	}
}
