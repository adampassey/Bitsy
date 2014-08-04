using UnityEngine;
using System.Collections.Generic;

namespace AdamPassey.Inventory
{
	[AddComponentMenu("Gameplay/Inventory GUI")]
	public class InventoryGUI : MonoBehaviour
	{
		public Vector2 itemOffset;
		public int tilesize;
		public Rect windowRect = new Rect(50, 50, 220, 200);

		private Inventory parentInventory;
		private GameObject[,] inventory;
		private DraggedItem draggedItem;

		public void Awake() {
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 *	Render the inventory GUI
		 **/
		void OnGUI() {
			//	using the Instance ID as the window ID
			windowRect = GUI.Window(gameObject.GetInstanceID(), windowRect, OnInventoryWindow, "");
		}

		/**
		 * 	Set the click-event handler
		 * 	Will notify the handler when an item
		 * 	is clicked, dragged, etc.
		 */
		public void SetInventoryEventHandler(Inventory handler) {
			parentInventory = handler;
		}

		/**
		 * 	Draw the inventory in a draggable window
		 **/
		public void OnInventoryWindow(int windowId) {
			Vector2 position = itemOffset;
			GUI.depth = InventoryLayer.MID;

			for (int x = 0; x < inventory.GetLength(0); x++) {
				for (int y = 0; y < inventory.GetLength(1); y++) {
					if (inventory[x, y] != null) {
						DrawInventoryItem(new InventoryPosition(x, y), position, tilesize, inventory[x, y].GetComponent<InventoryItem>());
					} else {
						DrawInventorySlot(new InventoryPosition(x, y), position, tilesize);
					}
					position.x += tilesize;
				}
				position.y += tilesize;
				position.x = itemOffset.y;
			}
			//	if there is no dragged item, 
			//	this window is draggable
			if (draggedItem.item == null) {
				GUI.DragWindow();
			}
		}

		/**
		 * 	Draw the specific inventory item
		 * 	@param position The [x, y] coordinates of the item
		 * 		in inventory. Used to send messages to Inventory
		 * 		with item location.
		 * 	@param guiPosition The [x, y] to draw the item at
		 * 	@param tilesize The size the inventory item should be.
		 * 		Assumed to be a square
		 * 	@param inventoryItem the inventory item itself
		 **/
		private void DrawInventoryItem(InventoryPosition position, Vector2 guiPosition, int tilesize, InventoryItem inventoryItem) {
			GUIContent guiContent = inventoryItem.GetGUIContent();
			Rect renderingRect = new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize);
			GUI.Box(renderingRect, guiContent);

			//	if the position of the current mouse event is within the rendering window
			if (renderingRect.Contains(UnityEngine.Event.current.mousePosition)) {

				//	and this is a mouseDrag or mouseUp event, handle it
				if (UnityEngine.Event.current.type == EventType.MouseDrag || UnityEngine.Event.current.type == EventType.MouseUp) {

					//	begin dragging this item
					if (draggedItem.item != null) {
						inventory[position.x, position.y] = draggedItem.item.gameObject;
						draggedItem.item = inventoryItem;
					} else {

						//	swap the dragged item with the one in this position
						draggedItem.item = inventoryItem;
						inventory[position.x, position.y] = null;
					}
					UnityEngine.Event.current.Use();
				}
			}
		}

		/**
		 * 	Draw an open inventory slot
		 **/
		private void DrawInventorySlot(InventoryPosition position, Vector2 guiPosition, int tilesize) {

			//	create the rendering rect to serve as the rendering position 
			//	and the event-receiving area
			Rect renderingRect = new Rect(guiPosition.x, guiPosition.y, tilesize, tilesize);
			GUI.Box(renderingRect, "");

			//	if the mouse is over this element, focus this window
			if (renderingRect.Contains(UnityEngine.Event.current.mousePosition)) {
				GUI.FocusWindow(gameObject.GetInstanceID());

				//	if there's a mouseUp event on this slot, drop the dragged item on it
				if (UnityEngine.Event.current.type == EventType.MouseUp && draggedItem.item != null) {
					inventory[position.x, position.y] = draggedItem.item.gameObject;
					draggedItem.item = null;
					UnityEngine.Event.current.Use();
				}
			}
		}

		/**
		 * 	Set the objects to render
		 * 	@param gameObjects List<GameObject>
		 **/
		public InventoryGUI SetObjects(GameObject[,] gameObjects) {
			inventory = gameObjects;
			return this;
		}

		/**
		 *	Show the inventory
		 *	@param parentInventory The inventory
		 **/
		public void Show() {
			gameObject.SetActive(true);
		}

		/**
		 * 	Hide the inventory GUI
		 **/
		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}