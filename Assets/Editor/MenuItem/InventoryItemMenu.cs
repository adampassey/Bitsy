using UnityEngine;
using UnityEditor;
using System.Collections;

using Bitsy.UserInterface.Inventory;

namespace Bitsy.Editor.MenuItems {

	public class InventoryItemMenu : MonoBehaviour {

		[MenuItem ("GameObject/Bitsy/Items/Inventory Item")]
		public static void CreateInventoryItemMenuItem() {
			GameObject obj = new GameObject();
			obj.name = "Inventory Item";
			obj.AddComponent<SpriteRenderer>();
			obj.AddComponent<BoxCollider2D>();
			obj.AddComponent<Rigidbody2D>();
			obj.AddComponent<InventoryItem>();
		}
	}
}
