using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AdamPassey.Inventory {

	[AddComponentMenu("Gameplay/Stackable Inventory Item")]
	public class StackableInventoryItem : InventoryItem {

		public int maxCount = 25;
		public int count = 1;

		/**
		 * 	Will display the number of items in this stack
		 * 
		 **/
		public override GUIContent GetGUIContent() {
			if (count > 1) {
				return new GUIContent(count.ToString(), texture);
			}
			return new GUIContent(texture);
		}

		/**
		 * 	Add a StackableInventoryItem to this item
		 * 	Will move all children up to the max count allowed
		 * 	including the parent item
		 * 
		 * 	@param StackableInventoryItem items The item stack to add
		 * 	@returns StackableInventoryItem the remaining items, or null
		 * 
		 **/
		public StackableInventoryItem AddStackableInventoryItems(StackableInventoryItem items) {
			if (count >= maxCount || items.itemName != this.itemName) {
				return items;
			}

			//	iterating through transforms as 
			//	`GetComponentsInChildren` does return the
			//	top level component, which we don't want
			//	so we'll create a transform list so we can
			//	mutate the transforms in items.transform
			//	and not break the loop

			List<Transform> tmpTransforms = new List<Transform>();
			foreach (Transform t in items.transform) {
				tmpTransforms.Add(t);
			}

			foreach (Transform t in tmpTransforms) {
				StackableInventoryItem child = t.GetComponent<StackableInventoryItem>();
				AddStackableInventoryItem(child);
				items.DecrementCount();
				if (count >= maxCount) {
					return items;
				}
			}

			//	add the top level stackable item
			AddStackableInventoryItem(items);
			return null;
		}

		/**
		 * 	Get the current count of items
		 * 
		 **/
		public int GetCount() {
			return count;
		}

		/**
		 * 	Is this stack at max?
		 * 
		 **/
		public bool IsMaxed() {
			return count == maxCount;
		}

		/**
		 * 	Specifically set the count of items in
		 * 	this stack
		 * 	
		 * 	@param int count The count
		 * 
		 **/
		public void SetCount(int count) {
			this.count = Mathf.Clamp(count, 1, maxCount);
		}

		/**
		 * 	Increment the count of this stack by one
		 * 	up to the max count
		 * 
		 **/
		public void IncrementCount() {
			if (count < maxCount) {
				count ++;
			}
		}

		/**
		 *	Decrement the count of this stack down
		 *	to one
		 **/
		public void DecrementCount() {
			if (count > 1) {
				count --;
			}
		}

		/**
		 * 	Drop this item and all children
		 * 
		 **/
		public override bool Drop(Vector2 pos) {
			Transform[] children = GetComponentsInChildren<Transform>(true);
			foreach (Transform child in children) {
				child.position = pos;
				child.gameObject.SetActive(true);
				child.parent = null;

				child.GetComponent<StackableInventoryItem>().SetCount(1);
			}
			return true;
		}

		private void AddStackableInventoryItem(StackableInventoryItem item) {
			item.transform.parent = this.transform;
			IncrementCount();
			item.DecrementCount();
		}
	}
}
