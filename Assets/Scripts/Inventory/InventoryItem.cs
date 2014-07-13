using UnityEngine;
using System.Collections;

namespace AdamPassey.Inventory
{
	[AddComponentMenu("Gameplay/Inventory Item")]
	public class InventoryItem : MonoBehaviour
	{
		public Texture2D texture;
		public string name;
		public string description;

		public GUIContent GetGUIContent() {
			GUIContent guiContent = new GUIContent();
			guiContent.tooltip = name;
			//guiContent.text = description;
			guiContent.image = texture;

			return guiContent;
		}
	}

}