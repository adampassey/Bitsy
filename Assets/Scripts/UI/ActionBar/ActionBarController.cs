using UnityEngine;
using System.Collections;

namespace Bitsy.UserInterface.ActionBar {

	public class ActionBarController : MonoBehaviour {

		private ActionBar actionBar;

		public static ActionBarController CreateComponent(GameObject parent, ActionBar actionBar) {
			ActionBarController controller = parent.AddComponent<ActionBarController>();
			controller.actionBar = actionBar;
			return controller;
		}
	
		public void Update() {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				actionBar.ActivateSlot(1);
			}

			if (Input.GetKeyDown(KeyCode.Alpha2)) {
				actionBar.ActivateSlot(2);
			}

			if (Input.GetKeyDown(KeyCode.Alpha3)) {
				actionBar.ActivateSlot(3);
			}

			if (Input.GetKeyDown(KeyCode.Alpha4)) {
				actionBar.ActivateSlot(4);
			}

			if (Input.GetKeyDown(KeyCode.Alpha5)) {
				actionBar.ActivateSlot(5);
			}

			if (Input.GetKeyDown(KeyCode.Alpha6)) {
				actionBar.ActivateSlot(6);
			}

			if (Input.GetKeyDown(KeyCode.Alpha7)) {
				actionBar.ActivateSlot(7);
			}

			if (Input.GetKeyDown(KeyCode.Alpha8)) {
				actionBar.ActivateSlot(8);
			}

			if (Input.GetKeyDown(KeyCode.Alpha9)) {
				actionBar.ActivateSlot(9);
			}

			if (Input.GetKeyDown(KeyCode.Alpha0)) {
				actionBar.ActivateSlot(0);
			}
		}
	}
}
