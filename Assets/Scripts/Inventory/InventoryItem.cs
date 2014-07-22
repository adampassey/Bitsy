using UnityEngine;
using System.Collections;

using AdamPassey.UI;

namespace AdamPassey.Inventory
{
	[AddComponentMenu("Gameplay/Inventory Item")]
	public class InventoryItem : MonoBehaviour
	{
		public Texture2D texture;
		public string name;
		public string description;
		public Vector2 popupOffset;

		public GUIContent GetGUIContent() {
			GUIContent guiContent = new GUIContent();
			guiContent.tooltip = name;
			guiContent.image = texture;

			return guiContent;
		}

		public void OnCollisionEnter2D(Collision2D collision) {
			ActorController actor = collision.gameObject.GetComponent<ActorController>();
			if (actor != null) {
				actor.collidedInventoryItem = gameObject;
			}
		}

		public void OnCollisionExit2D(Collision2D collision) {
			ActorController actor = collision.gameObject.GetComponent<ActorController>();
			if (actor != null) {
				actor.collidedInventoryItem = null;
			}
		}
	}
}