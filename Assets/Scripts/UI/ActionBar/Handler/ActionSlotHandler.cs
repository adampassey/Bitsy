using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Handler;

namespace Bitsy.UserInterface.ActionBar.Handler {

	public class ActionSlotHandler : DefaultSlotHandler {

		private ActionItem[] items;
		private int position;

		public ActionSlotHandler(GameObject window, ActionItem[] items, int position) : base(window) {
			this.items = items;
			this.position = position;
		}

		/**
		 * 	When an item is dropped on the slot, verify that it's
		 * 	an ActionItem and place it in items[]
		 **/
		public override bool ItemDropped(DraggableItem item) {
			ActionItem actionItem = item.GetComponent<ActionItem>();
			if (actionItem != null) {
				items[position] = actionItem;
				return true;
			}
			return false;
		}
	}
}
