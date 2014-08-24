using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface {

	public class DraggableItem : MonoBehaviour {

		public Texture2D texture;
		public string itemName;
		public string description;

		/**
		 * 	The GUI Content to display in UI
		 **/
		public virtual GUIContent GetGUIContent() {
			GUIContent guiContent = new GUIContent();
			guiContent.tooltip = itemName;
			guiContent.image = texture;
			
			return guiContent;
		}

		/**
		 * 	Drop this item
		 **/
		public virtual bool Drop(Vector2 pos) {
			gameObject.transform.position = pos;
			gameObject.SetActive(true);
			gameObject.transform.parent = null;
			return true;
		}
	}
}
