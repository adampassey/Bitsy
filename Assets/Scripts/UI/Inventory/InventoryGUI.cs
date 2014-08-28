#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Inventory.Handler;

namespace Bitsy.UserInterface.Inventory {

	[AddComponentMenu("Gameplay/Inventory GUI")]
	public class InventoryGUI : MonoBehaviour {

		public Vector2 itemOffset;
		public int tilesize;
		public Rect windowRect = new Rect(50, 50, 220, 200);
		public Rect draggableArea = new Rect(0, 0, 220, 50);

		private GameObject[,] inventory;
		private DraggedItem draggedItem;

		public void Start() {
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	Factory for building the InventoryGUI
		 * 	
		 * 	@param GameObject parent The parent game object to attach
		 * 		the GUI window to
		 * 	@param Inventory inventory The inventory
		 * 	@param Vector2 itemOffset The x, y offset of the items displaying
		 * 		in the GUI window
		 * 	@param int tilesize The size of the tiles (they're square)
		 * 	@param Rect windowSize The size of the GUI Window
		 * 
		 **/
		public static InventoryGUI CreateComponent(GameObject parent, Inventory inventory, Vector2 itemOffset, int tilesize, Rect windowSize, Rect draggableArea) {
			InventoryGUI inventoryGUI = parent.AddComponent<InventoryGUI>();

			inventoryGUI.itemOffset = itemOffset;
			inventoryGUI.tilesize = tilesize;
			inventoryGUI.windowRect = windowSize;
			inventoryGUI.draggableArea = draggableArea;
			inventoryGUI.Hide();

			return inventoryGUI;
		}

		/**
		 *	Render the inventory GUI
		 **/
		void OnGUI() {
			//	using the Instance ID as the window ID
			windowRect = GUI.Window(gameObject.GetInstanceID(), windowRect, OnInventoryWindow, "");
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
						//	create a UI.Draggable element
						InventoryItem item = inventory[x, y].GetComponent<InventoryItem>();
						InventoryDraggableHandler draggableHandler = new InventoryDraggableHandler(gameObject, new InventoryPosition(x, y), inventory, item); 
						UI.Draggable(new Rect(position.x, position.y, tilesize, tilesize), item.GetGUIContent(), new GUIStyle("button"), draggableHandler); 
					} else {
						//	create a UI.Slot
						InventorySlotHandler slotHandler = new InventorySlotHandler(gameObject, new InventoryPosition(x, y), inventory);
						UI.Slot(new Rect(position.x, position.y, tilesize, tilesize), new GUIStyle("button"), slotHandler);
					}
					position.x += tilesize;
				}
				position.y += tilesize;
				position.x = itemOffset.x;
			}
			//	if there is no dragged item, 
			//	this window is draggable
			if (draggedItem.item == null) {
				GUI.DragWindow(draggableArea);
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