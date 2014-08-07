using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.UserInterface
{
	public static class DraggableElement
	{

		private static DraggedItem draggedItem;

		static DraggableElement()
		{
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	Draw the specific inventory item
		 * 	@param position The [x, y] coordinates of the item
		 * 		in inventory. Used to send messages to Inventory
		 * 		with item location.
		 * 	@param guiPosition The [x, y] to draw the item at
		 * 	@param tilesize The size the inventory item should be.
		 * 		Assumed to be a square
		 * 	@param inventoryItem the inventory item itself
		 **/
		public static void Render(InventoryPosition position, Vector2 guiPosition, int tilesize, InventoryItem inventoryItem, GameObject[,] inventory) {
			GUIContent guiContent = inventoryItem.GetGUIContent();
			Rect renderingRect = new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize);
			GUI.Box(renderingRect, guiContent);
			
			//	if the position of the current mouse event is within the rendering window
			if (renderingRect.Contains(UnityEngine.Event.current.mousePosition)) {
				
				//	and this is a mouseDrag or mouseUp event, handle it
				if (UnityEngine.Event.current.type == EventType.MouseDrag || UnityEngine.Event.current.type == EventType.MouseUp) {
					
					//	begin dragging this item
					if (draggedItem.item != null) {
						inventory[position.x, position.y] = draggedItem.item.gameObject;
						draggedItem.item = inventoryItem;
					} else {
						
						//	swap the dragged item with the one in this position
						draggedItem.item = inventoryItem;
						inventory[position.x, position.y] = null;
					}
					UnityEngine.Event.current.Use();
				}
			}
		}
	}

}