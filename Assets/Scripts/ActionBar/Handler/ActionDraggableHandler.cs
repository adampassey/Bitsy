using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.ActionBar
{
	public class ActionDraggableHandler : DraggableHandler
	{

		private GameObject window;
		private ActionItem[] items;
		private ActionItem item;
		private int position;

		public ActionDraggableHandler(GameObject window, ActionItem[] items, int position)
		{
			this.window = window;
			this.items = items;
			this.position = position;
			this.item = items[position];
		}

		public void Hover() {

		}
		
		public void Hover(DraggableItem item) {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	Return the item in this slot as the 
		 * 	draggable item.
		 * 
		 **/
		public DraggableItem Drag() {
			ActionItem tmp = item.GetComponent<ActionItem>();
			items[position] = null;
			return tmp;
		}

		/**
		 * 	Activate an item on click
		 **/
		public DraggableItem Click() {
			//	TODO: add consume on use
			item.Use();
			return null;
		}

		/**
		 * 	When an item is dropped on this slot, swap
		 * 	it with the one currently in this place
		 * 
		 **/
		public DraggableItem ItemDropped(DraggableItem item) {
			if (item.GetComponent<ActionItem>() != null) {
				GameObject tmp = item.gameObject;
				items[position] = item.GetComponent<ActionItem>();
				return item.GetComponent<ActionItem>();
			}
			return null;
		}
	}
}
