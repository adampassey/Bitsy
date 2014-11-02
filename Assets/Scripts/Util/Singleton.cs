using UnityEngine;
using System.Collections;

namespace Bitsy.Util {

	/**
	 * A Singleton class for MonoBehaviours
	 * 
	 **/
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

		private static T instance;
	
		/**
		 * Retrieve the instance associated with this Singleton
		 * by constructing a new GameOBject, attaching a component
		 * and returning it.
		 * 
		 **/
		public static T GetInstance() {
			if (instance == null) {
				GameObject go = new GameObject();
				instance = go.AddComponent<T>();
			}
			return instance;
		}
	}
}
