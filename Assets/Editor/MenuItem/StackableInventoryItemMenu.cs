using UnityEngine;
using UnityEditor;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.Editor.MenuItems {
	
	public class StackableInventoryItemMenu : MonoBehaviour {
		
		[MenuItem ("GameObject/Bitsy/Items/Stackable Inventory Item")]
		public static void CreateInventoryItemMenuItem() {
			GameObject obj = new GameObject();
			obj.name = "Stackable Inventory Item";
			obj.AddComponent<SpriteRenderer>();
			obj.AddComponent<BoxCollider2D>();
			obj.AddComponent<Rigidbody2D>();
			obj.AddComponent<StackableInventoryItem>();
		}
	}
}
