using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.Equipment {

	public class EquipmentItem : InventoryItem {

		public EquipmentType equipmentType;
		public bool defaultRenderingLayer = true;

		private int renderingLayer;
		private SpriteRenderer spriteRenderer;

		public void Start() {
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
