using UnityEngine;
using UnityEditor;
using System.Collections;

using AdamPassey.Equipment;

namespace AdamPassey.Editor.MenuItems {
	
	public class EquipmentItemMenu : MonoBehaviour {
		
		[MenuItem ("GameObject/Bitsy/Items/Equipment Item")]
		public static void CreateInventoryItemMenuItem() {
			GameObject obj = new GameObject();
			obj.name = "Equipment Item";
			obj.AddComponent<SpriteRenderer>();
			obj.AddComponent<BoxCollider2D>();
			obj.AddComponent<Rigidbody2D>();
			obj.AddComponent<EquipmentItem>();
		}
	}
}
