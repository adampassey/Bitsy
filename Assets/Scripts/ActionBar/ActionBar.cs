using UnityEngine;
using System.Collections;

using AdamPassey.GameObjectHelper;

namespace AdamPassey.ActionBar {

	public class ActionBar : MonoBehaviour {

		public int maxItems = 10;
		public Vector2 offset;
		public int tilesize = 50;

		private GameObject actor;
		private ActionItem[] items;
		private GameObject actionBarGUIContainer;

		public void Start() {
			items = new ActionItem[maxItems];

			actionBarGUIContainer = GameObjectFactory.NewGameObject("Action Bar GUI Container", gameObject.transform);
			ActionBarGUI.CreateComponent(actionBarGUIContainer, this, items, offset, tilesize);

			ActionBarController.CreateComponent(gameObject, this);
		}
	
		/**
		 * 	Use an item in a given slot
		 * 	
		 * 	@param int slot The slot to use the item
		 * 
		 **/
		public void ActivateSlot(int slot) {
			if (items[slot] != null) {
				items[slot].Use(gameObject);
			}
		}
	}
}
