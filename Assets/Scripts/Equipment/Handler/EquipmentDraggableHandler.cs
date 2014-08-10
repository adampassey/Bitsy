using UnityEngine;
using System.Collections;

using AdamPassey.UserInterface;
using AdamPassey.UserInterface.Handler;

namespace AdamPassey.Equipment.Handler
{
	public class EquipmentDraggableHandler : DraggableHandler
	{
		private GameObject window;
		private DraggedItem draggedItem;
		private EquipmentType equipmentType;
		private Equipment equipment;

		public EquipmentDraggableHandler(GameObject window, EquipmentType equipmentType, Equipment equipment)
		{
			this.window = window;
			this.equipmentType = equipmentType;
			this.equipment = equipment;
			draggedItem = DraggedItem.GetInstance();
		}

		/**
		 * 	If we're not currently dragging, start a drag
		 **/
		public void MouseDrag(UnityEngine.Event e) {
			if (draggedItem.item == null) {
				StartDrag(e);
			}
		}
		
		/**
		 * 	A MouseUp event means the element was clicked
		 * 	OR a drag was released. If something is being dragged
		 * 	swap it with this item.
		 * 	Otherwise, start a drag.
		 * 
		 **/
		public void MouseUp(UnityEngine.Event e) {
			if (draggedItem.item != null && draggedItem.item.GetComponent<EquipmentItem>().equipmentType == equipmentType) {
				EquipmentItem tmpEquipmentItem = equipment.Unequip(equipmentType);
				equipment.Equip(equipmentType, draggedItem.item.GetComponent<EquipmentItem>());
				draggedItem.item = tmpEquipmentItem;
				e.Use();
			} else {
				StartDrag(e);
			}
		}
		
		/**
		 * 	Start a drag and use up this event
		 **/
		private void StartDrag(UnityEngine.Event e) {
			draggedItem.item = equipment.Unequip(equipmentType);
			e.Use();
		}
	}
}
