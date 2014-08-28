using UnityEngine;
using System.Collections;

namespace Bitsy.GameObjectHelper {

	public class GameObjectFactory {

		/**
		 * 	Create a GameObject with name
		 * 	@param name The name of the GameObject
		 **/
		public static GameObject NewGameObject(string name) {
			GameObject obj = new GameObject();
			obj.name = name;
			return obj;
		}

		/**
		 * 	Create a GameObject with a name and a
		 * 	parent transform
		 * 	@param name The name of the GameObject
		 * 	@param parent The parent transform
		 **/
		public static GameObject NewGameObject(string name, Transform parent) {
			GameObject obj = NewGameObject(name);
			obj.transform.parent = parent;
			return obj;
		}
	}
}
