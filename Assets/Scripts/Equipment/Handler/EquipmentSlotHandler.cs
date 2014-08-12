﻿using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Equipment.Handler
{
	public class EquipmentSlotHandler : SlotHandler
	{
		private GameObject window;
		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentSlotHandler(GameObject window, EquipmentType equipmentType, Equipment equipment)
		{
			this.window = window;
			this.equipmentType = equipmentType;
			this.equipment = equipment;
		}

		/**
		 * 	When hovered, focus this window
		 * 
		 **/
		public void Hover() {
			GUI.FocusWindow(window.GetInstanceID());
		}

		/**
		 * 	When an item is dropped on this slot, we'll check to
		 * 	see if that item is an EquipmentItem and if it matches
		 * 	this slot's type. 
		 * 
		 * 	Currently does not swap out equipment of different types.
		 * 
		 **/
		public bool ItemDropped(UnityEngine.Event e, DraggableItem item) {
			GameObject ob = item.gameObject;
			EquipmentItem equipmentItem = ob.GetComponent<EquipmentItem>();
			if (item != null && equipmentItem.equipmentType == equipmentType) {
				if (equipment.IsSlotFree(equipmentType)) {
					equipment.Equip(equipmentType, equipmentItem);
					return true;
				}
			}
			e.Use();
			return false;
		}
	}
}
