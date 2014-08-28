using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Handler;

namespace Bitsy.UserInterface.Inventory.Equipment.Handler {

	public class EquipmentDraggableHandler : DefaultDraggableHandler {

		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentDraggableHandler(GameObject window, EquipmentType equipmentType, Equipment equipment) : base(window) {
			this.equipmentType = equipmentType;
			this.equipment = equipment;
		}

		/**
		 * 	If we're not currently dragging, start a drag
		 **/
		public override DraggableItem Drag() {
			return StartDrag();
		}
		
		/**
		 * 	A MouseUp event means the element was clicked
		 * 	start a drag
		 * 
		 **/
		public override DraggableItem Click() {
			return StartDrag();
		}

		/**
		 *	If an item is dropped on this slot, check if it is an EquipmentItem
		 *	AND it is the proper EquipmentType
		 *	if so, equip it and return the previously equipped item (to be dragged)
		 *
		 *	Otherwise, return null
		 *
		 **/
		public override DraggableItem ItemDropped(DraggableItem item) {
			EquipmentItem equipmentItem = item.GetComponent<EquipmentItem>();
			if (equipmentItem != null && equipmentItem.equipmentType == equipmentType) {
				EquipmentItem tmpEquipmentItem = equipment.Unequip(equipmentType);
				equipment.Equip(equipmentType, item.GetComponent<EquipmentItem>());
				return tmpEquipmentItem;
			}
			return item;
		}
		
		/**
		 * 	Start a drag and use up this event
		 **/
		private DraggableItem StartDrag() {
			return equipment.Unequip(equipmentType);
		}
	}
}
