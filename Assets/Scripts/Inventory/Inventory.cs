using UnityEngine;
using System.Collections.Generic;

using AdamPassey.GameObjectHelper;

namespace AdamPassey.Inventory
{
	[AddComponentMenu("Gameplay/Inventory")]
	public class Inventory : MonoBehaviour
	{

		public List<GameObject> inventory;

		private GameObject parent;
		private static string parentName = "Inventory";
		private InventoryGUI inventoryGUI;

		public void Start() {
			inventory = new List<GameObject>();
			parent = GameObjectFactory.NewGameObject(parentName, gameObject.transform);
			inventoryGUI = parent.AddComponent<InventoryGUI>();
			inventoryGUI.Hide();
		}

		/**
		 * 	Add an object to the inventory
		 * 	@param obj The GameObject
		 **/
		public void AddObject(GameObject obj) {
			inventory.Add(obj);
			obj.SetActive(false);
			obj.transform.parent = parent.transform;
		}

		/**
		 * 	Get an object from the inventory at
		 * 	the given index
		 * 	@param index The index
		 **/
		public GameObject GetObject(int index) {
			GameObject obj = inventory[index];
			inventory.RemoveAt(index);
			obj.SetActive(true);
			obj.transform.parent = null;
			return obj;
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
			inventoryGUI.SetObjects(inventory).Show(this);
		}

		/**
		 * 	Hide the inventory GUI
		 **/
		public void Hide() {
			inventoryGUI.Hide();
		}
	}
}
