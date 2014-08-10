using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Equipment.Handler
{
	public class EquipmentSlotHandler : SlotHandler
	{
		private GameObject window;
		private DraggedItem draggedItem;
		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentSlotHandler(GameObject window, EquipmentType equipmentType, Equipment equipment)
		{
			this.window = window;
			this.equipmentType = equipmentType;
			this.equipment = equipment;
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	When hovered, focus this window if an item is
		 * 	being dragged.
		 * 
		 **/
		public void Hover() {
			if (draggedItem.item != null) {
				GUI.FocusWindow(window.GetInstanceID());
			}
		}

		/**
		 * 	When a MouseUp event happens, will first check to see
		 * 	if an item is being dragged. If it is, will check to see
		 * 	if that item is an EquipmentItem and if it matches this
		 * 	slot's type. 
		 * 
		 * 	Currently does not swap out equipment of different types.
		 **/
		public void MouseUp(UnityEngine.Event e) {
			if (draggedItem != null) {
				GameObject ob = draggedItem.item.gameObject;
				EquipmentItem item = ob.GetComponent<EquipmentItem>();
				if (item != null && item.equipmentType == equipmentType) {
					if (equipment.IsSlotFree(equipmentType)) {
						equipment.Equip(equipmentType, item);
						draggedItem.item = null;
					}
				}
			}
			e.Use();
		}
	}
}
