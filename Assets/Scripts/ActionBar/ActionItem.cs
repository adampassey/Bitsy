using UnityEngine;
using System.Collections;

using Bitsy.Inventory;

namespace Bitsy.ActionBar {

	public class ActionItem : MonoBehaviour {

		public bool destroyOnUse = false;

		public virtual void Use(GameObject user) {
			Debug.Log("Activating!");
			if (destroyOnUse) {
				Destroy(gameObject);
			}
		}
	}
}
