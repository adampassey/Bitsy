using UnityEngine;
using System.Collections;

namespace AdamPassey.UserInterface {

	/**
	 * 	Creates a button that overlays the screen-
	 * 	when clicked it will "drop" the item being
	 * 	dragged at the clicked position
	 **/
	public class DroppableScreenOverlay : MonoBehaviour {

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
			//	instead of drawing a GUI element, just check if a
			//	mouseUp event happens that propagates all the way to here
			Rect renderingRect = new Rect(0, 0, Screen.width, Screen.height);

			//	and drop the item (manually) if it does
			if (renderingRect.Contains(UnityEngine.Event.current.mousePosition)) {
				if (UnityEngine.Event.current.type == EventType.MouseUp && draggedItem.item != null) {

					//	will only drop the item if Drop() returns true
					if (draggedItem.item.Drop(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
						draggedItem.item = null;
					}

					UnityEngine.Event.current.Use();
				}
			}
		}
	}
}
