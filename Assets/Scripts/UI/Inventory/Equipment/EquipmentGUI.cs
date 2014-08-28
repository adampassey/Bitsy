using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Inventory.Equipment.Handler;

namespace Bitsy.UserInterface.Inventory.Equipment {

	public class EquipmentGUI : MonoBehaviour {

		public Equipment equipment;

		private Rect windowRect = new Rect(10, 10, 70, 200);
		private EquipmentSlotHandler handler;
		private DraggedItem draggedItem;

		public void Start() {
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	Factory for an EquipmentGUI
		 * 
		 * 	@param GameObject parent The parent GameObject to attach
		 * 		this component to
		 * 	@param Equipment equipment The Equipment object
		 **/
		public static EquipmentGUI CreateComponent(GameObject parent, Equipment equipment) {
			EquipmentGUI equipmentGUI = parent.AddComponent<EquipmentGUI>();
			equipmentGUI.equipment = equipment;
			return equipmentGUI;
		}

		public void OnGUI() {
			//	using the Instance ID as the window ID
			windowRect = GUI.Window(gameObject.GetInstanceID(), windowRect, OnEquipmentWindow, "");
		}

		/**
		 * 	Render the equipment GUI for each slot
		 **/
		public void OnEquipmentWindow(int windowId) {
			//	head slot
			if (equipment.IsSlotFree(EquipmentType.Head)) {
				EquipmentSlotHandler headHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Head, equipment);
				UI.Slot(new Rect(10, 55, 50, 50), new GUIStyle("button"), headHandler);
			} else {
				EquipmentDraggableHandler headHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Head, equipment);
				GUIContent guiContent = equipment.Item(EquipmentType.Head).GetGUIContent();
				UI.Draggable(new Rect(10, 55, 50, 50), guiContent, new GUIStyle("button"), headHandler);
			}
			GUI.Label(new Rect(18, 35, 100, 100), "Head");

			//	chest slot
			if (equipment.IsSlotFree(EquipmentType.Chest)) {
				EquipmentSlotHandler chestHandler = new EquipmentSlotHandler(gameObject, EquipmentType.Chest, equipment);
				UI.Slot(new Rect(10, 130, 50, 50), new GUIStyle("button"), chestHandler);
			} else {
				EquipmentDraggableHandler chestHandler = new EquipmentDraggableHandler(gameObject, EquipmentType.Chest, equipment);
				GUIContent guiContent = equipment.Item(EquipmentType.Chest).GetGUIContent();
				UI.Draggable(new Rect(10, 130, 50, 50), guiContent, new GUIStyle("button"), chestHandler);
			}
			GUI.Label(new Rect(18, 110, 100, 100), "Chest");

			if (draggedItem.item == null) {
				GUI.DragWindow(new Rect(0, 0, 70, 30));
			}
		}

		//	TODO: these are the same as inventoryGUI
		/**
		 *	Show the equipment
		 **/
		public void Show() {
			gameObject.SetActive(true);
		}
		
		/**
		 * 	Hide the GUI
		 **/
		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}
