using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Inventory.Handler {

	public class InventoryDraggableHandler : DefaultDraggableHandler {

		private InventoryPosition inventoryPosition;
		private GameObject[,] inventory;
		private InventoryItem item;

		public InventoryDraggableHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory, InventoryItem item) : base(window) {
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
			this.item = item;
		}

		/**
		 * 	When a Drag event is received
		 * 	start a drag
		 * 
		 **/
		public override DraggableItem Drag() {
			return StartDrag();
		}

		/**
		 * 	On Click start a drag
		 * 
		 **/
		public override DraggableItem Click() {
			return StartDrag();
		}

		/**
		 * 	An item was dropped on this slot. Swap it with the 
		 * 	item currently in that position and return it or
		 * 	stack it if it's a stackable item
		 * 
		 **/
		public override DraggableItem ItemDropped(DraggableItem item) {
			if (item.GetComponent<InventoryItem>() != null) {

				StackableInventoryItem stackableItem = item.GetComponent<StackableInventoryItem>();
				StackableInventoryItem stackableSelf = this.item.GetComponent<StackableInventoryItem>();

				//	if this is a stackable item, stack it
				if (stackableItem != null && stackableSelf != null) {
					if (!stackableSelf.IsMaxed()) {
						return stackableSelf.AddStackableInventoryItems(stackableItem);
					}
				}

				//	otherwise, swap it
				GameObject tmpInventoryItem = inventory[inventoryPosition.x, inventoryPosition.y];
				inventory[inventoryPosition.x, inventoryPosition.y] = item.gameObject;
				return tmpInventoryItem.GetComponent<InventoryItem>();
			}
			return null;
		}

		/**
		 * 	Start a drag and use up this event
		 **/
		private DraggableItem StartDrag() {
			inventory[inventoryPosition.x, inventoryPosition.y] = null;
			return item;
		}
	}
}
