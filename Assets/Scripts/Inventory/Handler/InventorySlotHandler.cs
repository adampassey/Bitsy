using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Inventory.Handler
{
	public class InventorySlotHandler : SlotHandler
	{
		private GameObject window;
		private InventoryPosition inventoryPosition;
		private GameObject[,] inventory;
		private DraggedItem draggedItem;

		public InventorySlotHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory)
		{
			this.window = window;
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
			this.draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	When a Hover event is received, let's make sure
		 * 	the parent window is active if something is being
		 * 	dragged. Otherwise, the window may not receive
		 * 	the drop (MouseUp) event.
		 * 
		 **/
		public void Hover() {
			if (draggedItem.item != null) {
				GUI.FocusWindow(window.GetInstanceID());
			}
		}

		/**
		 * 	On MouseUp, we check to see if there's currently an item
		 * 	being dragged. If there is, we drop it into this slot and
		 * 	use the event.
		 * 
		 **/
		public void MouseUp(UnityEngine.Event e) {
			if (draggedItem.item != null) {
				inventory[inventoryPosition.x, inventoryPosition.y] = draggedItem.item.gameObject;
				draggedItem.item = null;
				e.Use();
			}
		}
	}
}
