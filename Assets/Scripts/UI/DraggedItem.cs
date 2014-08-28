using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.UserInterface {

	/**
	 * 	Singleton that contains the item that is
	 * 	currently being dragged (set by InventoryGUI
	 * 	and potentially other scripts). Not meant to be
	 * 	added to the scene directly- instead use 
	 * 	`GetInstance` to retrieve and interact with instance
	 **/
	public class DraggedItem : MonoBehaviour {

		public int tilesize = 50;
		public DraggableItem item;

		private static DraggedItem instance;
		private GameObject droppableScreenOverlay;
		private bool showDroppableScreenOverlay = false;

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
		 *	Create a Droppable Screen Overlay that will receive
		 *	dragged items being dropped onto it.
		 *	Creating it separately is important to be able to 
		 *	explicitly handle the rendering order
		 **/
		public void Start() {
			droppableScreenOverlay = new GameObject();
			droppableScreenOverlay.gameObject.AddComponent<DroppableScreenOverlay>();
			droppableScreenOverlay.SetActive(false);
		}

		/**
		 * 	Will draw the `InventoryItem`s GUIContent
		 * 	at current mouse position when fired
		 **/
		public void OnGUI() {
			if (item == null) {
				showDroppableScreenOverlay = false;
				return;
			}

			GUI.depth = InventoryLayer.FRONT;
			GUIContent guiContent = item.GetGUIContent();

			Vector2 guiPosition = new Vector2();
			guiPosition.x = Input.mousePosition.x;
			guiPosition.y = Screen.height - Input.mousePosition.y;

			GUI.Box(new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize), guiContent);

			showDroppableScreenOverlay = true;
		}

		/**
		 *	For some reason, Unity doesn't like it if you use 
		 *	gameObject.SetActive(bool) in the OnGUI method. Because
		 *	of this, I'm using a bool to manage whether or not I'm
		 *	enabling the droppable screen overlay and setting it
		 *	here, during Update()
		 **/
		public void Update() {
			if (showDroppableScreenOverlay) {
				droppableScreenOverlay.SetActive(true);
			} else {
				droppableScreenOverlay.SetActive(false);
			}
		}
	}
}
