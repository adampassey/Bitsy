using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Handler;
using Bitsy.UserInterface.Inventory;

namespace Bitsy.UserInterface.ActionBar.Handler {

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

				//	if this is a stackable item, try and stack it
				//	this works but it's _really_ ugly
				//	TODO: maybe there should be a helper that will attempt
				//	this as opposed to implementing it on anything that
				//	requires stackable items.
				StackableInventoryItem stackableSelf = this.item.GetComponent<StackableInventoryItem>();
				StackableInventoryItem stackableItem = item.GetComponent<StackableInventoryItem>();
				if (stackableSelf != null && stackableItem != null) {

					//	if we're dragging a single item and dropping it on a max stack
					//	that means we should swap these 
					//	TODO: check stack types?
					if (stackableItem.GetCount() == 1 && stackableSelf.GetCount() == stackableSelf.maxCount) {
						items[position] = item.GetComponent<ActionItem>();
						return this.item.GetComponent<DraggableItem>();
					} else {
						StackableInventoryItem remainder = stackableSelf.AddStackableInventoryItems(stackableItem);
						if (remainder != null) {
							return remainder;
						}
					}
				} else {
					items[position] = item.GetComponent<ActionItem>();
					return this.item.GetComponent<DraggableItem>();
				}
			}
			return null;
		}
	}
}
