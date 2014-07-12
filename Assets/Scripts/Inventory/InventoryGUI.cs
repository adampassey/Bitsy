using UnityEngine;
using System.Collections.Generic;

namespace AdamPassey.Inventory
{
	public class InventoryGUI : MonoBehaviour
	{

		private Inventory parentInventory;
		private List<GameObject> inventory;

		/**
		 *	Render the inventory GUI
		 **/
		void OnGUI() {
			GUI.backgroundColor = Color.black;
			GUI.Box(new Rect(50, 50, 200, 200), "Inventory");

			Vector2 position = new Vector2(50, 50);
			for (int i = 0; i < inventory.Count; i++) {
				GameObject obj = inventory[i];
				InventoryItem inventoryItem = obj.GetComponent<InventoryItem>();

				if (GUI.Button(new Rect(position.x, position.y, 50, 50), inventoryItem.texture)) {
					//	TODO: Move this out into a handler
					//	currently dropping objects that are clicked
					GameObject droppedObject = parentInventory.GetObject(i);
					Vector3 pos = transform.position;
					pos.x += 1f;
					droppedObject.transform.position = pos;
				}

				//	TODO: Make a grid of objects
				//	instead of a row
				position.x += 50;
			}
		}

		/**
		 * 	Set the objects to render
		 * 	@param gameObjects List<GameObject>
		 **/
		public InventoryGUI SetObjects(List<GameObject> gameObjects) {
			inventory = gameObjects;
			return this;
		}

		/**
		 *	Show the inventory, currently requiring
		 *	an Inventory to handle the click events.
		 *	Yuck. Fix this junk.
		 *	@param parentInventory The inventory
		 **/
		//	TODO: clean up how this gets called
		public void Show(Inventory parentInventory) {
			this.parentInventory = parentInventory;
			gameObject.SetActive(true);
		}

		/**
		 * 	Hide the inventory GUI
		 **/
		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}