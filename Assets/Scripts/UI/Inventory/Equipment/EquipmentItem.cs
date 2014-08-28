using UnityEngine;
using System.Collections;

using Bitsy.UserInterface.Inventory;

namespace Bitsy.UserInterface.Inventory.Equipment {

	public class EquipmentItem : InventoryItem {

		public EquipmentType equipmentType;
		public bool defaultRenderingLayer = true;

		private int renderingLayer;
		private SpriteRenderer spriteRenderer;

		public override void Start() {
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			base.Start();
		}

		/**
		 * 	Will get called when an item is equipped
		 * 	currently setting the sorting layer based on
		 * 	the EquipmentType.
		 * 
		 **/
		public virtual void Equip() {
			if (defaultRenderingLayer) {
				renderingLayer = spriteRenderer.sortingLayerID;
				spriteRenderer.sortingOrder = (int)equipmentType;
			}
		}

		/**
		 * 	Will get called when an item id unequipped
		 * 	also setting the sorting layer based on 
		 * 	EquipmentType.
		 * 
		 **/
		public virtual void Unequip() {
			if (defaultRenderingLayer) {
				spriteRenderer.sortingOrder = renderingLayer;
			}
		}

	}
}
