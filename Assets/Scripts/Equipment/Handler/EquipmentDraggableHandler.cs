using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Equipment.Handler
{
	public class EquipmentDraggableHandler : DraggableHandler
	{
		private GameObject window;
		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentDraggableHandler(GameObject window, EquipmentType equipmentType, Equipment equipment)
		{
			this.window = window;
			this.equipmentType = equipmentType;
			this.equipment = equipment;
		}

		public void Hover() {
			
		}

		public void Hover(DraggableItem item) {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	If we're not currently dragging, start a drag
		 **/
		public DraggableItem Drag(UnityEngine.Event e) {
			return StartDrag(e);
		}
		
		/**
		 * 	A MouseUp event means the element was clicked
		 * 	start a drag
		 * 
		 **/
		public DraggableItem Click(UnityEngine.Event e) {
			return StartDrag(e);
		}

		/**
		 *	If an item is dropped on this slot, check if it is an EquipmentItem
		 *	AND it is the proper EquipmentType
		 *	if so, equip it and return the previously equipped item (to be dragged)
		 *
		 *	Otherwise, return null
		 *
		 **/
		public DraggableItem ItemDropped(UnityEngine.Event e, DraggableItem item) {
			EquipmentItem equipmentItem = item.GetComponent<EquipmentItem>();
			if (equipmentItem != null && equipmentItem.equipmentType == equipmentType) {
				EquipmentItem tmpEquipmentItem = equipment.Unequip(equipmentType);
				equipment.Equip(equipmentType, item.GetComponent<EquipmentItem>());
				return tmpEquipmentItem;
			}
			e.Use();
			return null;
		}
		
		/**
		 * 	Start a drag and use up this event
		 **/
		private DraggableItem StartDrag(UnityEngine.Event e) {
			e.Use();
			return equipment.Unequip(equipmentType);
		}
	}
}
