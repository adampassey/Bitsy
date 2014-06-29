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

		public void Start() {
			inventory = new List<GameObject>();
			parent = GameObjectFactory.NewGameObject(parentName, gameObject.transform);
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
	}
}
