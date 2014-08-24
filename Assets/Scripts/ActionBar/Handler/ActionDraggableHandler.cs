using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.ActionBar.Handler {

	public class ActionDraggableHandler : DefaultDraggableHandler {
		
		private ActionItem[] items;
		private ActionItem item;
		private int position;
		private ActionBar actionBar;

		public ActionDraggableHandler(GameObject window, ActionItem[] items, int position, ActionBar actionBar) : base(window) {
			this.items = items;
			this.position = position;
			this.item = items[position];
			this.actionBar = actionBar;
		}

		/**
		 * 	Return the item in this slot as the 
		 * 	draggable item.
		 * 
		 **/
		public override DraggableItem Drag() {
			DraggableItem tmp = item.GetComponent<DraggableItem>();
			items[position] = null;
			return tmp;
		}

		/**
		 * 	Activate an item on click
		 **/
		public override DraggableItem Click() {
			actionBar.ActivateSlot(position);
			return null;
		}

		/**
		 * 	When an item is dropped on this slot, swap
		 * 	it with the one currently in this place
		 * 
		 **/
		public override DraggableItem ItemDropped(DraggableItem item) {
			if (item.GetComponent<ActionItem>() != null) {
				items[position] = item.GetComponent<ActionItem>();
				return this.item.GetComponent<DraggableItem>();
			}
			return null;
		}
	}
}
