﻿using UnityEngine;
using System.Collections.Generic;

using AdamPassey.GameObjectHelper;
using AdamPassey.Animation;

namespace AdamPassey.Equipment
{
	[AddComponentMenu("Gameplay/Equipment")]
	public class Equipment : MonoBehaviour
	{
		public AnimationSync animationSync;

		private Dictionary<EquipmentType, GameObject> equipment;
		private EquipmentGUI equipmentGUI;
		private GameObject equipmentContainer;

		// Use this for initialization
		void Start() {
			equipment = new Dictionary<EquipmentType, GameObject>();
			equipmentContainer = GameObjectFactory.NewGameObject("Equipment", gameObject.transform);
			equipmentGUI = equipmentContainer.AddComponent<EquipmentGUI>();

			equipmentGUI.equipment = this;
		}

		/**
		 * 	Equip an item at a given type. This will disable the item's
		 * 	RigidBody2D and BoxCollider2D components, and will sync it's animation
		 * 	with the parent object.
		 * 
		 * 	@param EquipmentType type The "slot" to put the item in
		 * 	@param EquipmentItem item The item
		 **/
		public void Equip(EquipmentType type, EquipmentItem item) {
			DisableItem(item);
			item.gameObject.SetActive(true);
			item.gameObject.transform.parent = equipmentContainer.transform;
			item.transform.localPosition = Vector3.zero;
			equipment.Add(type, item.gameObject);

			animationSync.ReloadChildAnimators();
		}

		/**
		 * 	Unequip an item of a given type (slot). This will re-enable
		 * 	the item's RigidBody2D and BoxCollider2D components, and 
		 * 	will remove this object from the parent transform.
		 * 
		 * 	@param EquipmentType equipmentType the "slot" to remove the item from
		 **/
		public EquipmentItem Unequip(EquipmentType type) {
			if (equipment.ContainsKey(type)) {
				EquipmentItem item = equipment[type].GetComponent<EquipmentItem>();
				equipment.Remove(type);
				item.transform.parent = null;

				EnableItem(item);
				item.gameObject.SetActive(false);
				animationSync.ReloadChildAnimators();

				return item;
			}
			return null;
		}

		/**
		 * 	Get an item from a given equipment slot without removing it
		 * 	
		 * 	@param EquipmentType type The "slot" of the item
		 **/
		public EquipmentItem Item(EquipmentType type) {
			if (equipment.ContainsKey(type)) {
				EquipmentItem item = equipment[type].GetComponent<EquipmentItem>();
				return equipment[type].GetComponent<EquipmentItem>();
			}
			return null;
		}

		/**
		 * 	Check if this equipment slot is free
		 * 
		 * 	@param EquipmentType The "slot"
		 **/
		public bool IsSlotFree(EquipmentType type) {
			if (!equipment.ContainsKey(type)) {
				return true;
			}
			return equipment[type] == null;
		}

		/**
		 * 	Disable this item- should be called when an item is
		 * 	equipped. This will disable the BoxCollider2D and
		 * 	RigidBody2D components.
		 * 
		 * 	@param EquipmentItem item The item
		 **/
		private void DisableItem(EquipmentItem item) {
			item.GetComponent<BoxCollider2D>().enabled = false;
			item.rigidbody2D.isKinematic = true;
		}

		/**
		 * 	Enable this item- should be called when an item
		 * 	is unequipped. This will re-enable the BoxCollider2D
		 * 	and RigiBody2D components.
		 * 
		 * 	@param EquipmentItem item The item
		 **/
		private void EnableItem(EquipmentItem item) {
			item.GetComponent<BoxCollider2D>().enabled = true;
			item.rigidbody2D.isKinematic = false;
		}

		//	TODO: these are the same methods from
		//	inventory, clean them up

		/**
		 * 	Convenience method to determine if the
		 * 	equipment GUI is visible
		 **/
		public bool IsVisible() {
			return equipmentGUI.gameObject.activeSelf;
		}
		
		/**
		 * 	Show the equipment GUI
		 **/
		public void Show() {
			equipmentGUI.Show();
		}
		
		/**
		 * 	Hide the equipment GUI
		 **/
		public void Hide() {
			equipmentGUI.Hide();
		}
	}
}