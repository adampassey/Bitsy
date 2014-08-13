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

		public InventoryDraggableHandler(GameObject window, InventoryPosition inventoryPosition, GameObject[,] inventory, InventoryItem item)
		{
			this.window = window;
			this.inventoryPosition = inventoryPosition;
			this.inventory = inventory;
			this.item = item;
		}

		public void Hover() {
			
		}
		
		public void Hover(DraggableItem item) {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	When a Drag event is received
		 * 	start a drag
		 * 
		 **/
		public DraggableItem Drag() {
			return StartDrag();
		}

		/**
		 * 	On Click start a drag
		 * 
		 **/
		public DraggableItem Click() {
			return StartDrag();
		}

		/**
		 * 	An item was dropped on this slot. Swap it with the 
		 * 	item currently in that position and return it
		 * 
		 **/
		public DraggableItem ItemDropped(DraggableItem item) {
			GameObject tmpInventoryItem = inventory[inventoryPosition.x, inventoryPosition.y];
			inventory[inventoryPosition.x, inventoryPosition.y] = item.gameObject;
			return tmpInventoryItem.GetComponent<InventoryItem>();
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
