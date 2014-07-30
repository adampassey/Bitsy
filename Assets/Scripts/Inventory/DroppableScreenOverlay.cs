using UnityEngine;
using System.Collections;

namespace AdamPassey.Inventory
{
	/**
	 * 	Creates a button that overlays the screen-
	 * 	when clicked it will "drop" the item being
	 * 	dragged at the clicked position
	 **/
	public class DroppableScreenOverlay : MonoBehaviour
	{
		private DraggedItem draggedItem;

		/**
		 * 	Retrieve the DraggedItem singleton
		 * 	and set the name of this object
		 **/
		public void Awake() {
			draggedItem = DraggedItem.GetInstance();
			name = "Droppable Screen Overlay";
		}

		/**
		 * 	Render the button behind all other inventory GUI
		 * 	components. When this button is clicked it will
		 * 	drop the currently dragged item at the location
		 **/
		public void OnGUI() {
			//	draw the button that receives drop events
			GUIStyle guiStyle = new GUIStyle();
			GUI.depth = InventoryLayer.BACKGROUND;

			if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", guiStyle)) {
				if (UnityEngine.Event.current.button == 0 && draggedItem.item != null) {
					GameObject obj = draggedItem.item.gameObject;

					//	TODO: dropping object at mouse position
					//	yes this is not ideal- should drop
					//	near the player
					Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					pos.z = 0;
					obj.transform.position = pos;
					obj.SetActive(true);
					obj.transform.parent = null;
					draggedItem.item = null;
				}
			}
		}
	}
}
