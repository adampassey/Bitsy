using UnityEngine;
using System.Collections.Generic;

using AdamPassey.GameObjectHelper;

namespace AdamPassey.Inventory {

	[AddComponentMenu("Gameplay/Inventory")]
	public class Inventory : MonoBehaviour {

		public Rect guiSize = new Rect(50, 50, 220, 200);
		public Vector2 inventorySize;
		public Vector2 itemOffset;
		public int tilesize;
		public GameObject[,] inventory;

		private GameObject parent;
		private static string parentName = "Inventory";
		private InventoryGUI inventoryGUI;

		public void Start() {
			inventory = new GameObject[(int)inventorySize.x, (int)inventorySize.y];
			parent = GameObjectFactory.NewGameObject(parentName, gameObject.transform);
			inventoryGUI = InventoryGUI.CreateComponent(parent, this, itemOffset, tilesize, guiSize);
		}

		/**
		 * 	Add an object to the inventory
		 * 	Will add the object to the first open 
		 * 	location found.
		 * 
		 * 	If this is a stackable item it will attempt
		 * 	to stack it in each slot that is a stackable item.
		 * 	If there is a remainder of items, it will place them
		 * 	at the first emtpy slot
		 * 
		 * 	@param obj The GameObject
		 **/
		public void AddObject(GameObject obj) {
			StackableInventoryItem stackableItem = obj.GetComponent<StackableInventoryItem>();
			InventoryPosition defaultPosition = null;

			for (int x = 0; x < inventory.GetLength(0); x++) {
				for (int y = 0; y < inventory.GetLength(1); y++) {
					if (inventory[x, y] == null) {
						if (stackableItem == null) {
							AddObject(new InventoryPosition(x, y), obj);
							return;
						} else if (defaultPosition == null) {
							defaultPosition = new InventoryPosition(x, y);
						}
					} else {
						if (stackableItem != null) {
							StackableInventoryItem inventoryItem = inventory[x, y].GetComponent<StackableInventoryItem>();
							if (inventoryItem != null) {
								StackableInventoryItem remainder = inventoryItem.AddStackableInventoryItems(stackableItem);
								if (remainder == null) {
									return;
								}
							}
						}
					}
				}
			}
			if (defaultPosition != null) {
				AddObject(defaultPosition, obj);
			}
		}

		/**
		 * 	Add an object at the specific position
		 * 	@param InventoryPosition the position
		 * 	@param obj The GameObject
		 **/
		public void AddObject(InventoryPosition position, GameObject obj) {
			inventory[position.x, position.y] = obj;
			obj.SetActive(false);
			obj.transform.parent = parent.transform;
		}

		/**
		 * 	Get an object from the inventory at
		 * 	the given position.
		 * 	@param position The position
		 **/
		public GameObject GetObject(InventoryPosition position) {
			GameObject obj = inventory[position.x, position.y];
			if (obj == null) {
				return null;
			}

			inventory[position.x, position.y] = null;
			obj.SetActive(true);
			obj.transform.parent = null;
			return obj;
		}

		/**
		 * 	Get an object from unknown position
		 * 	@param GameObject the object to remove
		 * 		from inventory
		 **/
		public GameObject GetObject(GameObject obj) {
			for (int x = 0; x < inventory.GetLength(0); x++) {
				for (int y = 0; y < inventory.GetLength(1); y++) {
					if (inventory[x, y] == obj) {
						return GetObject(new InventoryPosition(x, y));
					}
				}
			}
			return null;
		}

		/**
		 * 	Convenience method to determine if the
		 * 	inventory GUI is visible
		 **/
		public bool IsVisible() {
			return inventoryGUI.gameObject.activeSelf;
		}

		/**
		 * 	Show the inventory GUI
		 **/
		public void Show() {
			inventoryGUI.SetObjects(inventory).Show();
		}

		/**
		 * 	Hide the inventory GUI
		 **/
		public void Hide() {
			inventoryGUI.Hide();
		}
	}
}
