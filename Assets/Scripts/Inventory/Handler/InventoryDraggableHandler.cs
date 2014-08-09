using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Inventory.Handler
{
	public class InventoryDraggableHandler : DraggableHandler
	{
		private GameObject window;
		private InventoryPosition inventoryPosition;
		private GameObject[,] inventory;
		private InventoryItem item;
		private DraggedItem draggedItem;

		public InventoryDraggableHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory, InventoryItem item)
		{
			this.window = window;
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
			this.item = item;
			this.draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	When a MouseDrag event is received
		 * 	start a drag if there's nothing currently
		 * 	being dragged.
		 * 
		 **/
		public void MouseDrag(UnityEngine.Event e) {
			if (draggedItem.item == null) {
				StartDrag(e);
			}
		}

		/**
		 * 	A MouseUp event means the element was clicked
		 * 	OR a drag was released. If something is being dragged
		 * 	swap it with this item.
		 * 	Otherwise, start a drag.
		 * 
		 **/
		public void MouseUp(UnityEngine.Event e) {
			if (draggedItem.item != null) {
				inventory[inventoryPosition.x, inventoryPosition.y] = draggedItem.item.gameObject;
				draggedItem.item = null;
				e.Use();
			} else {
				StartDrag(e);
			}
		}

		/**
		 * 	Start a drag and use up this event
		 **/
		private void StartDrag(UnityEngine.Event e) {
			draggedItem.item = item;
			inventory[inventoryPosition.x, inventoryPosition.y] = null;
			e.Use();
		}
	}
}
