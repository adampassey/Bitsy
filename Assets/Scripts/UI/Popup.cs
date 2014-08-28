using UnityEngine;
using System.Collections;

namespace Bitsy.UserInterface {

	public class Popup : MonoBehaviour {

		public string content;
		public Vector2 objectPosition;
		public Vector2 popupOffset;

		public void OnGUI() {
			Camera camera = Camera.main;
			Vector3 screenPos = camera.WorldToScreenPoint(objectPosition);

			//	TODO: allow styling, more flexibility
			//	should probably be attached to the actor
			//	instead of items. That way multiples won't
			//	be on screen at once. 
			Rect pos = new Rect(screenPos.x + popupOffset.x, screenPos.y + popupOffset.y, 100f, 100f);
			GUI.Label(pos, content);
		}
	}
}
