using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;

namespace AdamPassey.Inventory {

	/**
	 * 	All items that can be added to the inventory
	 * 	should have this component attached. This component
	 * 	is used to handle collisions (for pickup) as well
	 * 	as set the content of the GUI elements displayed
	 * 	in the inventory.
	 * 
	 **/
	[AddComponentMenu("Gameplay/Inventory Item")]
	public class InventoryItem : DraggableItem {

		/**
		 * 	Currently using a propery in Actor to set the
		 * 	collided inventory item. 
		 **/
		//	TODO: I don't like this. Doesn't work well for
		//	multiple collisions
		public void OnCollisionEnter2D(Collision2D collision) {
			ActorController actor = collision.gameObject.GetComponent<ActorController>();
			if (actor != null) {
				actor.collidedInventoryItem = gameObject;
			}
		}

		//	TODO: same as above
		public void OnCollisionExit2D(Collision2D collision) {
			ActorController actor = collision.gameObject.GetComponent<ActorController>();
			if (actor != null) {
				actor.collidedInventoryItem = null;
			}
		}
	}
}