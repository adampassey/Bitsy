using UnityEngine;
using System.Collections;

using AdamPassey.Inventory;

namespace AdamPassey.ActionBar
{
	public class ActionItem : InventoryItem
	{
		public virtual void Use() {
			Debug.Log("Activating!");
		}
	}
}
