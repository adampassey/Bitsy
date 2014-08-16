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

		public InventorySlotHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory)
		{
			this.window = window;
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
		}

		/**
		 * 	When a Hover event is received, focus the parent
		 * 	window.
		 * 
		 **/
		public void Hover() {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	On MouseUp, we check to see if there's currently an item
		 * 	being dragged. If there is, we drop it into this slot.
		 * 
		 **/
		public bool ItemDropped(DraggableItem item) {
			if (item.GetComponent<InventoryItem>() != null) {
				inventory[inventoryPosition.x, inventoryPosition.y] = item.gameObject;
				return true;
			}
			return false;
		}
	}
}
