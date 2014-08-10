using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface
{
	public class DraggableItem : MonoBehaviour
	{
		public Texture2D texture;
		public string name;
		public string description;

		private DraggedItem draggedItem;

		public void Awake() {
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	The GUI Content to display in UI
		 **/
		public virtual GUIContent GetGUIContent() {
			GUIContent guiContent = new GUIContent();
			guiContent.tooltip = name;
			guiContent.image = texture;
			
			return guiContent;
		}

		/**
		 * 	Drop this item
		 **/
		public virtual void Drop() {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = 0;
			gameObject.transform.position = pos;
			gameObject.SetActive(true);
			gameObject.transform.parent = null;
			draggedItem.item = null;
		}
	}
}
