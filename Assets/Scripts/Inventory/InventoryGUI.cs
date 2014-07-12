using UnityEngine;
using System.Collections.Generic;

namespace AdamPassey.Inventory
{
	[AddComponentMenu("Gameplay/Inventory")]
	public class InventoryGUI : MonoBehaviour
	{

		private Inventory parentInventory;
		private List<GameObject> inventory;

		private Rect windowRect = new Rect(50, 50, 220, 200);

		/**
		 *	Render the inventory GUI
		 **/
		void OnGUI() {
			windowRect = GUI.Window(0, windowRect, OnInventoryWindow, "Inventory");
		}

		/**
		 * 	Draw the inventory in a draggable window
		 **/
		public void OnInventoryWindow(int windowId) {
			Vector2 position = new Vector2(10, 20);
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
				if (i != 0 && i % 4 == 0) {
					position.x = 10;
					position.y += 50;
				} else {
					position.x += 50;
				}
			}
			//	called at the end as to not
			//	overwrite button clicks
			GUI.DragWindow();
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