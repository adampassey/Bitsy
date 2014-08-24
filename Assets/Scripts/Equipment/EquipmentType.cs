using UnityEngine;
using System.Collections;

namespace AdamPassey.Equipment {

	/**
	 * 	The different types of equipment.
	 * 	Also determines the rendering layer.
	 * 	The types appearing at the top of the
	 * 	list render at the very back.
	 * 
	 **/
	public enum EquipmentType {
		Back,
		Chest,
		Head,
		Legs,
		Hands,
		Feet
	}
}
