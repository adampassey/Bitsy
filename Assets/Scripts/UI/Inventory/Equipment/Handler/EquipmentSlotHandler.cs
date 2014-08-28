using UnityEngine;
using System.Collections;

using Bitsy.UserInterface;
using Bitsy.UserInterface.Handler;

namespace Bitsy.UserInterface.Inventory.Equipment.Handler {

	public class EquipmentSlotHandler : DefaultSlotHandler {

		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentSlotHandler(GameObject window, EquipmentType equipmentType, Equipment equipment) : base(window) {
			this.equipmentType = equipmentType;
			this.equipment = equipment;
		}

		/**
		 * 	When an item is dropped on this slot, we'll check to
		 * 	see if that item is an EquipmentItem and if it matches
		 * 	this slot's type. 
		 * 
		 * 	Currently does not swap out equipment of different types.
		 * 
		 **/
		public override bool ItemDropped(DraggableItem item) {
			EquipmentItem equipmentItem = item.GetComponent<EquipmentItem>();
			if (equipmentItem != null && equipmentItem.equipmentType == equipmentType) {
				if (equipment.IsSlotFree(equipmentType)) {
					equipment.Equip(equipmentType, equipmentItem);
					return true;
				}
			}
			return false;
		}
	}
}
