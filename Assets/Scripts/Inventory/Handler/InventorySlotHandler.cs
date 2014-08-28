using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Inventory.Handler {

	public class InventorySlotHandler : DefaultSlotHandler {

		private InventoryPosition inventoryPosition;
		private GameObject[,] inventory;

		public InventorySlotHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory) : base(window) {
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
		}

		/**
		 * 	On MouseUp, we check to see if there's currently an item
		 * 	being dragged. If there is, we drop it into this slot.
		 * 
		 **/
		public override bool ItemDropped(DraggableItem item) {
			if (item.GetComponent<InventoryItem>() != null) {
				inventory[inventoryPosition.x, inventoryPosition.y] = item.gameObject;
				return true;
			}
			return false;
		}
	}
}
