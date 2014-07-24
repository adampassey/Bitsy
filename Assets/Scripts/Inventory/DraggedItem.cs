using UnityEngine;
using System.Collections;

namespace AdamPassey.Inventory
{
	/**
	 * 	Singleton that contains the item that is
	 * 	currently being dragged (set by InventoryGUI
	 * 	and potentially other scripts). Not meant to be
	 * 	added to the scene directly- instead use 
	 * 	`GetInstance` to retrieve and interact with instance
	 **/
	public class DraggedItem : MonoBehaviour
	{
		public int tilesize = 50;
		public InventoryItem item;

		private static DraggedItem instance;

		/**
		 *	Get the instance
		 **/
		public static DraggedItem GetInstance() {
			if (instance == null) {
				GameObject go = new GameObject();
				go.name = "Dragged Item Singleton";
				instance = go.AddComponent<DraggedItem>();
			}
			return instance;
		}

		/**
		 * 	Will draw the `InventoryItem`s GUIContent
		 * 	at current mouse position when fired
		 **/
		public void OnGUI() {
			if (item == null) {
				return;
			}

			//	render the item in the front
			GUI.depth = InventoryLayer.BACK;

			GUIContent guiContent = item.GetGUIContent();

			Vector2 guiPosition = new Vector2();
			guiPosition.x = Input.mousePosition.x;
			guiPosition.y = Screen.height - Input.mousePosition.y;

			GUI.Button(new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize), guiContent);
		}
	}
}
