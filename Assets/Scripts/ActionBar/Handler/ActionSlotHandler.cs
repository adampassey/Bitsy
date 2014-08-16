using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.ActionBar
{
	public class ActionSlotHandler : SlotHandler
	{
		private GameObject window;
		private ActionItem[] items;
		private int position;

		public ActionSlotHandler(GameObject window, ActionItem[] items, int position)
		{
			this.window = window;
			this.items = items;
			this.position = position;
		}

		public void Hover() {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	When an item is dropped on the slot, verify that it's
		 * 	an ActionItem and place it in items[]
		 **/
		public bool ItemDropped(DraggableItem item) {
			ActionItem actionItem = item.GetComponent<ActionItem>();
			if (actionItem != null) {
				items[position] = actionItem;
				return true;
			}
			return false;
		}
	}
}
